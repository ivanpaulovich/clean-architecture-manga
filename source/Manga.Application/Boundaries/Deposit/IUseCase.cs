namespace Manga.Application.Boundaries.Deposit
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(Input input);
    }
}