namespace Domain.Accounts
{
    using System.Threading.Tasks;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public interface IAccountRepository
    {
        Task<IAccount> Get(AccountId id);

        Task Add(IAccount account, ICredit credit);

        Task Update(IAccount account, ICredit credit);

        Task Update(IAccount account, IDebit debit);

        Task Delete(IAccount account);
    }
}
