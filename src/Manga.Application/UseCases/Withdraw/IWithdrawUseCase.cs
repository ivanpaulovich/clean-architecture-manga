namespace Manga.Application.UseCases.Withdraw
{
    using Manga.Domain.ValueObjects;
    using System;
    using System.Threading.Tasks;

    public interface IWithdrawUseCase
    {
        Task<WithdrawOutput> Execute(Guid accountId, Amount amount);
    }
}
