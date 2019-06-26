namespace Manga.Application.Boundaries.GetCustomerDetails
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}