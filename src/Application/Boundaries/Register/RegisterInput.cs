namespace Application.Boundaries.Register
{
    using Domain.ValueObjects;

    public sealed class RegisterInput : IUseCaseInput
    {
        public SSN SSN { get; }
        public PositiveMoney InitialAmount { get; }

        public RegisterInput(
            SSN ssn,
            PositiveMoney initialAmount)
        {
            SSN = ssn;
            InitialAmount = initialAmount;
        }
    }
}