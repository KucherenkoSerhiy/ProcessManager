namespace ProcessManager.Application.Process.Validators
{
    using Conditions;
    using DDD;
    using Models.Commands;

    public class CreateProcessCommandValidator: IValidator<CreateProcessCommand>
    {
        public void Validate(CreateProcessCommand valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Process.Requires().IsNotNull();
            valueToValidate.Process.Name.Requires().IsNotNullOrWhiteSpace();
        }
    }
}
