namespace Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;

    public sealed class GetCustomerDetailsOutput : IUseCaseOutput
    {
        public GetCustomerDetailsOutput(
            ExternalUserId externalUserId,
            ICustomer customer,
            List<Account> accounts)
        {
            ExternalUserId = externalUserId;
            Customer customerEntity = (Customer)customer;
            CustomerId = customerEntity.Id;
            SSN = customerEntity.SSN;
            Name = customerEntity.Name;
            Accounts = accounts;
        }

        public ExternalUserId ExternalUserId { get; }

        public CustomerId CustomerId { get; }

        public SSN SSN { get; }

        public Name Name { get; }

        public IReadOnlyList<Account> Accounts { get; }
    }
}
