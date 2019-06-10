namespace Manga.Application.Boundaries.Withdraw
{
    using System.Threading.Tasks;
    using System;
    using Manga.Domain.ValueObjects;

    public interface IUseCase
    {
        Task Execute(Guid accountId, Amount amount);
    }
}