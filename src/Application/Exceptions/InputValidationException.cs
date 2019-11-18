namespace Application.Exceptions
{
    using Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message)
            : base(message)
        {
        }
    }
}
