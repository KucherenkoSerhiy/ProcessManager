namespace IoC.Interface
{
    using System;
    using System.Collections.Generic;
    using Enum;

    public interface IIoCComponent
    {
        Type Interface { get; }
        Type Implementation { get; }
        string Name { get; set; }
        LifeStyleType LifeStyleType { get; set; }
        IDictionary<string, object> Dependencies { get; set; }
        bool IsDefault { get; set; }
    }
}