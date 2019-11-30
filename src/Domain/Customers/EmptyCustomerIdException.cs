namespace Domain.Customers
{
    internal sealed class EmptyCustomerIdException : DomainException
    {
        internal EmptyCustomerIdException(string message)
            : base(message)
        {
        }
    }
}
