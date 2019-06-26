namespace Manga.Application.Boundaries.GetCustomerDetails
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(Input input);
    }
}