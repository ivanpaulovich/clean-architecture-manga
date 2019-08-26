namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(GetAccountDetailsInput getAccountDetailsInput);
    }
}