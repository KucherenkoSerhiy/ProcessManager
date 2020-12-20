namespace IoC._IoCInstaller
{
    using System.Collections.Generic;
    using IoC;
    using Enum;
    using Interface;
    using Logger;

    public class Installer: IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var commonServices = new List<IIoCComponent>
            {
                new IoCComponent<ILogger, Logger>
                {
                    Name = nameof(Logger),
                    LifeStyleType = defaultLifeStyleType
                }
            };
            IoCContainerManager.Container.Register(commonServices);
        }
    }
}
