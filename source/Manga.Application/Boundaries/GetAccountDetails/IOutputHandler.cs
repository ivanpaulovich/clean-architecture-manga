namespace Manga.Application.Boundaries.GetAccountDetails
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(GetAccountDetailsOutput output);
        void NotFound(string message);
    }
}