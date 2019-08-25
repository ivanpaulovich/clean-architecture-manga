namespace Manga.Application.Boundaries.GetAccountDetails
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
        void NotFound(string message);
    }
}