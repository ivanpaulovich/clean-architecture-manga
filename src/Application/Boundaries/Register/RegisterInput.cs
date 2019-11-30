namespace Application.Boundaries.Register
{
    using Domain.Accounts;
    using Domain.Customers;

    public sealed class RegisterInput : IUseCaseInput
    {
        public RegisterInput(
            SSN ssn,
            PositiveMoney initialAmount)
        {
            SSN = ssn;
            InitialAmount = initialAmount;
        }

        public SSN SSN { get; }

        public PositiveMoney InitialAmount { get; }
    }
}
