namespace Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using Domain.Accounts;
    using Domain.ValueObjects;

    public interface IAccountRepository
    {
        Task<IAccount> Get(Guid id);
        Task<IAccount> Get(ExternalUserId externalUserId, Guid id);
        Task Add(IAccount account, ICredit credit);
        Task Update(IAccount account, ICredit credit);
        Task Update(IAccount account, IDebit debit);
        Task Delete(IAccount account);
    }
}