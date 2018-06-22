namespace Manga.Application.Repositories
{
    using Manga.Domain.Accounts;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account, Credit credit);
        Task Update(Account account, Credit credit);
        Task Update(Account account, Debit debit);
        Task Delete(Account account);
    }
}
