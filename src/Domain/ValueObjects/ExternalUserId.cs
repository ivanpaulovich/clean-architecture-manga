namespace Domain.ValueObjects
{
    using System;

    public readonly struct ExternalUserId : IEquatable<ExternalUserId>
    {
        private readonly string _text;

        public ExternalUserId(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ExternalUserIdShouldNotBeEmptyException($"The '{nameof(text)}' field is required");

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public bool Equals(ExternalUserId other) => _text == other._text;

        public override bool Equals(object obj) => obj is ExternalUserId other && Equals(other);

        public override int GetHashCode() => _text != null ? _text.GetHashCode() : 0;
    }
}