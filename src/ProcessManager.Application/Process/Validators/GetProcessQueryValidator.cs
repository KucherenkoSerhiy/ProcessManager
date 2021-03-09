namespace ProcessManager.Application.Process.Validators
{
    using DDD;
    using Conditions;
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
