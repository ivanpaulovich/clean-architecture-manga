namespace Acerola.Domain.ValueObjects
{
    public class Name
    {
        public string Text { get; private set; }

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new NameShouldNotBeEmptyException("The 'Name' field is required");

            this.Text = text;
        }

        public static Name Create(string text)
        {
            return new Name(text);
        }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
