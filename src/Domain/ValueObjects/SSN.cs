namespace Domain.ValueObjects
{
    using System.Text.RegularExpressions;
    using System;

    public readonly struct SSN : IEquatable<SSN>
    {
        private readonly string _text;
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

        public override string ToString() => _text;

        public bool Equals(SSN other) => _text == other._text;

        public override bool Equals(object obj) => obj is SSN other && Equals(other);

        public override int GetHashCode() => _text != null ? _text.GetHashCode() : 0;
    }
}