namespace IoC.Interface
{
    using Enum;

    public interface IIoCInstaller
    {
        void Install(LifeStyleType defaultLifeStyleType);
    }
}