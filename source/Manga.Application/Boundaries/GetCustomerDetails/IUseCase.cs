namespace Manga.Application.Boundaries.GetCustomerDetails
{
    using System.Threading.Tasks;
    using System;

    public interface IUseCase
    {
        Task Execute(Guid customerId);
    }
}