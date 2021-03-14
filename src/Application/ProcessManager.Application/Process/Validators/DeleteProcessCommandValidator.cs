namespace ProcessManager.Process.Application.Process.Validators
{
    using Conditions;
    using Core.DDD;
    using Models.Commands;

    public class DeleteProcessCommandValidator: IValidator<DeleteProcessCommand>
    {
        public void Validate(DeleteProcessCommand valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Id.Requires().IsNotNullOrWhiteSpace();
        }
    }
}
