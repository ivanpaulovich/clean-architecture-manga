namespace Application.Boundaries.Register
{
    using Domain.ValueObjects;

    public sealed class RegisterInput : IUseCaseInput
    {
        public SSN SSN { get; }
        public Name Name { get; }
        public PositiveMoney InitialAmount { get; }

        public RegisterInput(SSN ssn, Name name, PositiveMoney initialAmount)
        {
            SSN = ssn;
            Name = name;
            InitialAmount = initialAmount;
        }
    }
}