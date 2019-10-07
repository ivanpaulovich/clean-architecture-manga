namespace Manga.Application.Boundaries.Register
{
    using Manga.Domain.ValueObjects;

    public sealed class RegisterInput
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
