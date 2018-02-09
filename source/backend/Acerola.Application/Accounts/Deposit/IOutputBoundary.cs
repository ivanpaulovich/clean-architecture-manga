namespace Acerola.Application.Accounts.Deposit
{
    public interface IOutputBoundary
    {
        void Handle(Response response);
    }
}
