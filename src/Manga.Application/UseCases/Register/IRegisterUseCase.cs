namespace Manga.Application.UseCases.Register
{
    using Manga.Domain.ValueObjects;
    using System.Threading.Tasks;

    public interface IRegisterUseCase
    {
        Task<RegisterOutput> Execute(SSN personnummer, Name name, Amount initialAmount);
    }
}
