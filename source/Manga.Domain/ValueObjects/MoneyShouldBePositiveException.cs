namespace Manga.Domain.ValueObjects
{
    public sealed class MoneyShouldBePositiveException : DomainException
    {
        internal MoneyShouldBePositiveException(string message) : base(message) { }
    }
}