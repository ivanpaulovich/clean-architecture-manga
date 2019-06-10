namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System.Threading.Tasks;
    using System;

    public interface IUseCase
    {
        Task Execute(Guid accountId);
    }
}