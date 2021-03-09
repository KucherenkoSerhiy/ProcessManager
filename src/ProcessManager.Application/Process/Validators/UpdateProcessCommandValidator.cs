
namespace ProcessManager.Application.Process.Validators
{
    using DDD;
    using Models.Commands;
    using Conditions;

    public class UpdateProcessCommandValidator: IValidator<UpdateProcessCommand>
    {
        public void Validate(UpdateProcessCommand valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Process.Requires().IsNotNull();
            valueToValidate.Process.ProcessId.Requires().IsNotNullOrWhiteSpace();
        }
    }
}
