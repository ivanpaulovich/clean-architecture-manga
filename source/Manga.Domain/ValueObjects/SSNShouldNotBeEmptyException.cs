namespace Manga.Domain.ValueObjects
{
    public sealed class SSNShouldNotBeEmptyException : DomainException
    {
        internal SSNShouldNotBeEmptyException(string message) : base(message) { }
    }
}