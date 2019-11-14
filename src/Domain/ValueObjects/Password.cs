namespace Domain.ValueObjects
{
    using System;

    public readonly struct Password : IEquatable<Password>
    {
        private readonly string _text;

        public Password(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new PasswordShouldNotBeEmptyException("The 'Password' field is required");

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public bool Equals(Password other)
            => _text == other._text;

        public override bool Equals(object obj)
            => obj is Password other && Equals(other);

        public override int GetHashCode()
            => _text != null ? _text.GetHashCode() : 0;
    }
}
