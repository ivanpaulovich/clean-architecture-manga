namespace Application.Boundaries.Withdraw
{
    public interface IOutputPort
    {
        void Standard(WithdrawOutput withdrawOutput);
        void NotFound(string message);
        void OutOfBalance(string message);
    }
}