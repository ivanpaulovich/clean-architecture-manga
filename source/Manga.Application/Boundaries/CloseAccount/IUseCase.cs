namespace Manga.Application.Boundaries.CloseAccount
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(Input input);
    }
}