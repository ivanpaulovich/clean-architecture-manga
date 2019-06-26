namespace Manga.Domain.ValueObjects
{
    public sealed class NameShouldNotBeEmptyException : DomainException
    {
        internal NameShouldNotBeEmptyException(string message) : base(message) { }
    }
}