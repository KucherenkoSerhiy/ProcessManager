namespace ProcessManager.Application.Process.Validators
{
    using Conditions;
    using DDD;
    using Models.Queries;

    public class GetProcessesQueryValidator: IValidator<GetProcessesQuery>
    {
        public void Validate(GetProcessesQuery valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
        }
    }
}
