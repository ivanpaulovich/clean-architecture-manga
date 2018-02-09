namespace Acerola.Application.Accounts.Close
{
    public interface IOutputBoundary
    {
        void Handle(Response response);
    }
}
