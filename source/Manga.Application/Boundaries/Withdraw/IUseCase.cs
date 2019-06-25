namespace Manga.Application.Boundaries.Withdraw
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(Input input);
    }
}