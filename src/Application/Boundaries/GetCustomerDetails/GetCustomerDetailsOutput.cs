namespace Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// Gets Customer Details Output Message.
    /// </summary>
    public sealed class GetCustomerDetailsOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomerDetailsOutput"/> class.
        /// </summary>
        /// <param name="externalUserId">External User Id.</param>
        /// <param name="customer">Customer object.</param>
        /// <param name="accounts">Accounts list.</param>
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

        /// <summary>
        /// Gets the ExternalUserId.
        /// </summary>
        public ExternalUserId ExternalUserId { get; }

        /// <summary>
        /// Gets the CustomerId.
        /// </summary>
        public CustomerId CustomerId { get; }

        /// <summary>
        /// Gets the SSN.
        /// </summary>
        public SSN SSN { get; }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public Name Name { get; }

        /// <summary>
        /// Gets the Accounts.
        /// </summary>
        public IReadOnlyList<Account> Accounts { get; }
    }
}
