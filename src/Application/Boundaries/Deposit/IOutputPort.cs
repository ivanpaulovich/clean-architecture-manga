namespace Application.Boundaries.Deposit
{
    public interface IOutputPort
        : IOutputPortStandard<DepositOutput>, IOutputPortNotFound
    {
    }
}