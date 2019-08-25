namespace Manga.Application.Boundaries.GetCustomerDetails
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(GetCustomerDetailsOutput output);
        void NotFound(string message);
    }
}