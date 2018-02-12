namespace Manga.Domain.ValueObjects
{
    public class AmountShouldBePositiveException : DomainException
    {
        internal AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}
