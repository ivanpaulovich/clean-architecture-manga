namespace Manga.Application.Boundaries.Register
{
    using Manga.Domain.ValueObjects;

    public sealed class Input
    {
        public SSN SSN { get; }
        public Name Name { get; }
        public PositiveAmount InitialAmount { get; }
        
        public Input(SSN ssn, Name name, PositiveAmount initialAmount)
        {
            SSN = ssn;
            Name = name;
            InitialAmount = initialAmount;
        }
    }
}