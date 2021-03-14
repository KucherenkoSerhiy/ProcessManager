namespace IoC.Interface
{
    using System.Collections.Generic;

    public interface IIoCResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}