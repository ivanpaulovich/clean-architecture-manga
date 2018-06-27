namespace Manga.Domain.ValueObjects
{
    using System.Text.RegularExpressions;

    public sealed class SSN
    {
        private string _text;
        const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

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

        public static implicit operator SSN(string text)
        {
            return new SSN(text);
        }

        public static implicit operator string(SSN ssn)
        {
            return ssn._text;
        }
    }
}
