namespace Domain.ValueObjects
{
    public readonly struct Password
    {
        private readonly string _text;

        public Password(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new PasswordShouldNotBeEmptyException("The 'Password' field is required");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
