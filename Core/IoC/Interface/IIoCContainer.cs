namespace IoC.Interface
{
    using System.Collections.Generic;

    public interface IIoCContainer
    {
        void Register(IList<IIoCComponent> components);

        T Resolve<T>(string name = "");

        List<T> ResolveAll<T>();
    }
}