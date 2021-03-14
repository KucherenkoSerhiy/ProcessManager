namespace ProcessManager.Core.DDD
{
    public interface IValidator<T>
    {
        void Validate(T valueToValidate);
    }
}