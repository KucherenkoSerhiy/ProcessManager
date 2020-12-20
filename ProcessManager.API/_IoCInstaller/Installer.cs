namespace ProcessManager.API._IoCInstaller
{
    using System.Collections.Generic;
    using API.Dummy;
    using Dummy.Impl;
    using IoC;
    using IoC.Enum;
    using IoC.Interface;

    public class Installer: IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var dummyServices = new List<IIoCComponent>
            {
                new IoCComponent<IDummy, Dummy>
                {
                    Name = nameof(Dummy),
                    LifeStyleType = defaultLifeStyleType
                }
            };
            IoCContainerManager.Container.Register(dummyServices);
        }
    }
}
