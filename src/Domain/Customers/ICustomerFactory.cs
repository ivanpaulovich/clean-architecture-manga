namespace Domain.Customers
{
    using Domain.Customers.ValueObjects;

    public interface ICustomerFactory
    {
        ICustomer NewCustomer(SSN ssn, Name name);
    }
}
