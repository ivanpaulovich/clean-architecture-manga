namespace Manga.Domain.ValueObjects
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

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
