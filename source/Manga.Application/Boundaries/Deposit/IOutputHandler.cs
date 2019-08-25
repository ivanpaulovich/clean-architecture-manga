namespace Manga.Application.Boundaries.Deposit
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(DepositOutput output);
    }
}