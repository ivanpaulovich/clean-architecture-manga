namespace Application.Boundaries.RegisterAccount
{
    using Domain.ValueObjects;

    public sealed class RegisterAccountInput : IUseCaseInput
    {
        public SSN SSN { get; }
        public Name Name { get; }
        public PositiveMoney InitialAmount { get; }

        public RegisterAccountInput(SSN ssn, Name name, PositiveMoney initialAmount)
        {
            SSN = ssn;
            Name = name;
            InitialAmount = initialAmount;
        }
    }
}
