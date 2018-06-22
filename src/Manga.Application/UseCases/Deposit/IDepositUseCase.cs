namespace Manga.Application.UseCases.Deposit
{
    using Manga.Domain.ValueObjects;
    using System;
    using System.Threading.Tasks;

    public interface IDepositUseCase
    {
        Task<DepositOutput> Execute(Guid accountId, Amount amount);
    }
}
