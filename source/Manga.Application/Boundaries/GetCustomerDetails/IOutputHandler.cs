namespace Manga.Application.Boundaries.GetCustomerDetails
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
        void NotFound(string message);
    }
}