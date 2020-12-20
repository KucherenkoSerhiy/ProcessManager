namespace IoC.Windsor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.MsDependencyInjection;
    using Enum;
    using Interface;
    using Logger;
    using Microsoft.Extensions.DependencyInjection;

    public class WindsorIocContainer: IIoCContainer
    {
        private readonly IWindsorContainer container;
        private readonly IServiceProvider serviceProvider;

        public WindsorIocContainer(IServiceCollection services)
        {
            this.container = new WindsorContainer();
            this.container.Kernel.ComponentRegistered += this.OnComponentRegistered;
            this.serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(this.container, services);
        }

        public void Register(IList<IIoCComponent> components)
        {
            foreach (var component in components)
            {
                bool isAlreadyRegistered = this.CheckIfAlreadyRegistered(component);
                if (!isAlreadyRegistered)
                {
                    if (component.LifeStyleType == LifeStyleType.None)
                    {
                        string message =
                            $"No lifeStyle defined for the component {component.Interface.FullName}. Please define lifeStyle";
                        throw new ArgumentException(message);
                    }

                    var windsorComponent =
                        Component.For(component.Interface).ImplementedBy(component.Implementation);
                    if (!string.IsNullOrEmpty(component.Name))
                        windsorComponent.Named(component.Name);
                    this.UpdateComponentDependencies(ref windsorComponent, component.Dependencies);
                    if (component.IsDefault)
                        windsorComponent.IsDefault();
                    Enum.TryParse<LifestyleType>(component.LifeStyleType.ToString(), true, out var result);
                    windsorComponent.LifeStyle.Is(result);

                    this.container.Register((IRegistration) windsorComponent);
                }
            }
        }

        public T Resolve<T>(string name = "")
        {
            return !string.IsNullOrEmpty(name) ? this.container.Resolve<T>(name) : this.container.Resolve<T>();
        }

        public List<T> ResolveAll<T>()
        {
            return this.container.ResolveAll<T>().ToList();
        }

        public IServiceProvider GetServiceProvider() {
            return this.serviceProvider;
        } 

        private void UpdateComponentDependencies(
            ref ComponentRegistration<object> windsorComponent, 
            IDictionary<string, object> componentDependencies)
        {
            foreach (var dependency in componentDependencies)
            {
                if (dependency.Value.GetType() == typeof(IoCNamedComponentDependency))
                    windsorComponent.DependsOn(ServiceOverride.ForKey(dependency.Key)
                        .Eq(((IoCNamedComponentDependency) dependency.Value).Name));
                else
                    windsorComponent.DependsOn(Property.ForKey(dependency.Key).Eq(dependency.Value));
            }
        }

        private bool CheckIfAlreadyRegistered(IIoCComponent component)
        {
            bool emptyName = string.IsNullOrEmpty(component.Name);
            bool hasImplementation = this.container.Kernel.HasComponent(component.Name);
            bool hasInterface = this.container.Kernel.HasComponent(component.Interface);
            var isAlreadyRegistered = !emptyName && hasImplementation || emptyName && hasInterface;
            if (isAlreadyRegistered)
            {
                string message =
                    $"Trying to register component {component.Implementation.FullName} named as {component.Name} but {component.Interface.FullName} was already registered.";
                Logger.Instance.Debug(message);
            }

            return isAlreadyRegistered;
        }

        private void OnComponentRegistered(string key, IHandler handler)
        {
            Type implementation = handler.ComponentModel.Implementation;
            string implementationFullName = (object) implementation != null ? implementation.FullName : null;
            Type type = handler.ComponentModel.Implementation.UnderlyingSystemType.GetInterfaces().FirstOrDefault();
            string typeFullName = (object) type != null ? type.FullName : null;

            string message = $"Registered component '{implementationFullName}' for '{typeFullName}' with name '{key}'";
            Logger.Instance.Debug(message);
        }
    }
}
