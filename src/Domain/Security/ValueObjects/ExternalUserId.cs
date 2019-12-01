namespace Domain.Security.ValueObjects
{
    public readonly struct ExternalUserId
    {
        private readonly string _text;

        public ExternalUserId(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ExternalUserIdShouldNotBeEmptyException($"The '{nameof(text)}' field is required.");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
