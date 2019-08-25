namespace Manga.Application.Boundaries.Withdraw
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(WithdrawOutput output);
    }
}