namespace DDD
{
    public interface IValidator<T>
    {
        void Validate(T valueToValidate);
    }
}