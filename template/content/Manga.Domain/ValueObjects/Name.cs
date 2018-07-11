namespace Manga.Domain.ValueObjects
{
    public sealed class Name
    {
        private string _text;

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new NameShouldNotBeEmptyException("The 'Name' field is required");

            _text = text;
        }

        public static implicit operator Name(string text)
        {
            return new Name(text);
        }

        public static implicit operator string(Name name)
        {
            return name._text;
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

            return ((Name)obj)._text == _text;
        }
    }
}
