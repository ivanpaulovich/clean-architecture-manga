namespace Manga.Domain.Customers
{
    public sealed class CustomerNotFoundException : DomainException
    {
        public CustomerNotFoundException(string message) : base(message) { }
    }
}
