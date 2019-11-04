namespace Domain.ValueObjects
{
    using System;

    public struct Name : IEquatable<Name>
    {
        private readonly string _text;

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new NameShouldNotBeEmptyException("The 'Name' field is required");

            _text = text;
        }

        public override string ToString()
            => _text;

        public bool Equals(Name other)
            => _text == other._text;

        public override bool Equals(object obj)
            => obj is Name other && Equals(other);

        public override int GetHashCode()
            => _text != null ? _text.GetHashCode() : 0;
    }
}
