namespace Manga.Application.Boundaries.GetCustomerDetails
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(GetCustomerDetailsOutput getCustomerDetailsOutput);
        void NotFound(string message);
    }
}