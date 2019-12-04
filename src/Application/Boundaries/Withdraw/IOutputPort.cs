namespace Application.Boundaries.Withdraw
{
    public interface IOutputPort
        : IOutputPortStandard<WithdrawOutput>, IOutputPortNotFound
    {
        void OutOfBalance(string message);
    }
}