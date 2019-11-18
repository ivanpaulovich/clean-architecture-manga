namespace Domain.ValueObjects
{
    public readonly struct Name
    {
        private readonly string _text;

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException("The 'Name' field is required");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
