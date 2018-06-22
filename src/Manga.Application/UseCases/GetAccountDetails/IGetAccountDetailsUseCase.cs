namespace Manga.Application.UseCases.GetAccountDetails
{
    using System;
    using System.Threading.Tasks;

    public interface IGetAccountDetailsUseCase
    {
        Task<AccountOutput> Execute(Guid accountId);
    }
}
