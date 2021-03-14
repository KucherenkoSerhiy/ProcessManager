
namespace ProcessManager.Process.Application.Process.Validators
{
    using Conditions;
    using Core.DDD;
    using Models.Commands;

    public class UpdateProcessCommandValidator: IValidator<UpdateProcessCommand>
    {
        public void Validate(UpdateProcessCommand valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Process.Requires().IsNotNull();
            valueToValidate.Process.Id.Requires().IsNotNullOrWhiteSpace();
            valueToValidate.Process.Name.Requires().IsNotNullOrWhiteSpace();
        }
    }
}
