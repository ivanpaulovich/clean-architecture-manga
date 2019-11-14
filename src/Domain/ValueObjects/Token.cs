namespace Domain.ValueObjects
{
    using System;

    public readonly struct Token : IEquatable<Token>
    {
        private readonly string _text;

        public Token(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new TokenShouldNotBeEmptyException("The 'Token' field is required");

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public bool Equals(Token other)
            => _text == other._text;

        public override bool Equals(object obj)
            => obj is Token other && Equals(other);

        public override int GetHashCode()
            => _text != null ? _text.GetHashCode() : 0;
    }
}
