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
        {
            return _text;
        }

        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return obj.ToString() == _text;
            }

            return ((Name) obj)._text == _text;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _text.GetHashCode();
                return hash;
            }
        }

        public bool Equals(Name other)
        {
            return _text == other._text;
        }
    }
}
