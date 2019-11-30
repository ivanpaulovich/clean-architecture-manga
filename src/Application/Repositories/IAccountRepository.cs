namespace Application.Repositories
{
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;

    public interface IAccountRepository
    {
        Task<IAccount> Get(AccountId id);

        Task Add(IAccount account, ICredit credit);

        Task Update(IAccount account, ICredit credit);

        Task Update(IAccount account, IDebit debit);

        Task Delete(IAccount account);
    }
}
