namespace IoC
{
    using System;
    using System.Collections.Generic;
    using Enum;
    using Interface;

    public class IoCComponent<TI, TC>: IIoCComponent
    {
        public Type Interface => typeof(TI);
        public Type Implementation => typeof(TC);
        public string Name { get; set; }
        public LifeStyleType LifeStyleType { get; set; }
        public IDictionary<string, object> Dependencies { get; set; }
        public bool IsDefault { get; set; }

        public IoCComponent()
        {
            this.Dependencies = (IDictionary<string, object>) new Dictionary<string, object>();
            this.LifeStyleType = LifeStyleType.None;
        }


    }
}
