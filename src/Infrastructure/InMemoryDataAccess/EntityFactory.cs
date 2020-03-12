namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;

    /// <summary>
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">
    ///         Entity
    ///         Factory Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class EntityFactory : IUserFactory, ICustomerFactory, IAccountFactory
    {
        public IAccount NewAccount(CustomerId customerId) => new Account(
            new AccountId(Guid.NewGuid()),
            customerId,
            Array.Empty<Credit>(),
            Array.Empty<Debit>());

        public ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate) => new Credit(
            new CreditId(Guid.NewGuid()),
            account.Id,
            amountToDeposit,
            transactionDate
        );

        public IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate) => new Debit(
            new DebitId(Guid.NewGuid()),
            account.Id,
            amountToWithdraw,
            transactionDate
        );

        public ICustomer NewCustomer(SSN ssn, Name name) => new Customer(
            new CustomerId(Guid.NewGuid()),
            ssn,
            name,
            Array.Empty<AccountId>()
        );

        public IUser NewUser(CustomerId customerId, ExternalUserId externalUserId) => new User(
            customerId,
            externalUserId
        );
    }
}
