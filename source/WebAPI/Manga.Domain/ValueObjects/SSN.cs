namespace Manga.Domain.ValueObjects
{
    using System.Text.RegularExpressions;

    public sealed class SSN
    {
        public string _text { get; private set; }
        const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        public SSN(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new SSNShouldNotBeEmptyException("The 'SSN' field is required");

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(text);

            if (!match.Success)
                throw new InvalidSSNException("Invalid SSN format. Use YYMMDDNNNN.");

            this._text = text;
        }

        public override string ToString()
        {
            return _text.ToString();
        }

        public static implicit operator SSN(string text)
        {
            return new SSN(text);
        }

        public static implicit operator string(SSN ssn)
        {
            return ssn._text;
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

            return ((SSN)obj)._text == _text;
        }

        public override int GetHashCode()
        {
            return _text.GetHashCode();
        }
    }
}
