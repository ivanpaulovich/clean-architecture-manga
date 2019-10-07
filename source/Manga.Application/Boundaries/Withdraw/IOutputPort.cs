namespace Manga.Application.Boundaries.Withdraw
{
    public interface IOutputPort
    {
        void Standard(WithdrawOutput withdrawOutput);
    }
}
