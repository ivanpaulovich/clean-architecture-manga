namespace Manga.Application.Boundaries.Deposit
{
    public interface IOutputHandler : IErrorHandler
    {
        void Default(DepositOutput depositOutput);
    }
}