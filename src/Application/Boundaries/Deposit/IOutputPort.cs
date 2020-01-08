namespace Application.Boundaries.Deposit
{
    /// <summary>
    /// Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<DepositOutput>, IOutputPortNotFound
    {
    }
}
