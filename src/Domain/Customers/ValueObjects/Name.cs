namespace Domain.Customers.ValueObjects
{
    /// <summary>
    /// Name <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct Name
    {
        private readonly string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> struct.
        /// </summary>
        /// <param name="text">Name.</param>
        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException($"The {nameof(text)} field is required.");
            }

            this._text = text;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return this._text;
        }
    }
}
