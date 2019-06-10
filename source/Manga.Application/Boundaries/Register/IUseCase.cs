namespace Manga.Application.Boundaries.Register
{
    using System.Threading.Tasks;
    using Manga.Domain.ValueObjects;

    public interface IUseCase
    {
        Task Execute(SSN personnummer, Name name, Amount initialAmount);
    }
}