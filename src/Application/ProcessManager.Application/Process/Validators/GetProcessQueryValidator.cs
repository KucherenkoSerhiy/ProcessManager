namespace ProcessManager.Process.Application.Process.Validators
{
    using Conditions;
    using Core.DDD;
    using Models.Queries;

    public class GetProcessQueryValidator: IValidator<GetProcessQuery>
    {
        public void Validate(GetProcessQuery valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Id.Requires().IsNotNullOrWhiteSpace();
        }
    }
}
