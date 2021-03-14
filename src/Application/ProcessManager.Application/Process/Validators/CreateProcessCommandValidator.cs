namespace ProcessManager.Process.Application.Process.Validators
{
    using Conditions;
    using Core.DDD;
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
