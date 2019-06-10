namespace Manga.Application.Boundaries.Deposit
{
    using System.Threading.Tasks;
    using System;
    using Manga.Domain.ValueObjects;

    public interface IUseCase
    {
        Task Execute(Guid accountId, Amount amount);
    }
}