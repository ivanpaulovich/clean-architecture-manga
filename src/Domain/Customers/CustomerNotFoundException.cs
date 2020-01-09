namespace Domain.Customers
{
    /// <summary>
    /// Customer Not Found Exception.
    /// </summary>
    public sealed class CustomerNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CustomerNotFoundException(string message)
            : base(message)
        {
        }
    }
}
