namespace Manga.Application.Boundaries.CloseAccount
{
    using System.Threading.Tasks;
    using System;

    public interface IUseCase
    {
        Task Execute(Guid accountId);
    }
}