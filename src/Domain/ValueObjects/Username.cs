namespace Domain.ValueObjects
{
    using System;

    public readonly struct Username : IEquatable<Username>
    {
        private readonly string _text;

        public Username(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new UsernameShouldNotBeEmptyException("The 'Username' field is required");

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public bool Equals(Username other)
            => _text == other._text;

        public override bool Equals(object obj)
            => obj is Username other && Equals(other);

        public override int GetHashCode()
            => _text != null ? _text.GetHashCode() : 0;
    }
}
