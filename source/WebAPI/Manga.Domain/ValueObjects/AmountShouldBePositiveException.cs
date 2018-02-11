namespace Manga.Domain.ValueObjects
{
    public class AmountShouldBePositiveException : DomainException
    {
        public AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}
