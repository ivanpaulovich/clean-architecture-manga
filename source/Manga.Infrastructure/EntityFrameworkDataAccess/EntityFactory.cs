namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using Manga.Domain;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;

    public sealed class EntityFactory : IEntityFactory
    {
        public IAccount NewAccount(ICustomer customer)
        {
            var account = new Account(customer);
            return account;
        }

        public ICredit NewCredit(IAccount account, PositiveAmount amountToDeposit)
        {
            var credit = new Credit(account, amountToDeposit);
            return credit;
        }

        public ICustomer NewCustomer(SSN ssn, Name name)
        {
            var customer = new Customer(ssn, name);
            return customer;
        }

        public IDebit NewDebit(IAccount account, PositiveAmount amountToWithdraw)
        {
            var debit = new Debit(account, amountToWithdraw);
            return debit;
        }
    }
}