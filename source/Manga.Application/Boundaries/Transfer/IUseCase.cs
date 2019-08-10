namespace Manga.Application.Boundaries.Transfer
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(Input input);
    }
}