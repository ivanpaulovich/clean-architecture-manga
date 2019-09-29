namespace Manga.Application.Boundaries.GetAccountDetails
{
    public interface IOutputPort
    {
        void Standard(GetAccountDetailsOutput getAccountDetailsOutput);
        void NotFound(string message);
    }
}