namespace Manga.Application.Exceptions
{
    using Manga.Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}