namespace Manga.Domain.ValueObjects
{
    using System.Text.RegularExpressions;
    using System;

    public sealed class SSN : IEquatable<SSN>
    {
        private string _text;
        const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        private SSN() { }

        public SSN(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new SSNShouldNotBeEmptyException("The 'SSN' field is required");

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(text);

            if (!match.Success)
                throw new InvalidSSNException("Invalid SSN format. Use YYMMDDNNNN.");

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public bool Equals(SSN other)
        {
            return this._text == other._text;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _text;
            }

            return ((SSN) obj)._text == _text;
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
    }
}