namespace Acerola.Application.Accounts.Withdraw
{
    public interface IOutputBoundary
    {
        void Handle(Response response);
    }
}
