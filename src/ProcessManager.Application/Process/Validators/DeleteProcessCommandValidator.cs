namespace ProcessManager.Application.Process.Validators
{
    using DDD;
    using Models.Commands;
    using Conditions;

    public class DeleteProcessCommandValidator: IValidator<DeleteProcessCommand>
    {
        public void Validate(DeleteProcessCommand valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Id.Requires().IsNotNullOrWhiteSpace();
        }
    }
}
