namespace Manga.Application.Boundaries.Register
{
    using System.Threading.Tasks;
    using Manga.Domain.ValueObjects;

    public interface IUseCase
    {
        Task Execute(SSN ssn, Name name, PositiveAmount initialAmount);
    }
}