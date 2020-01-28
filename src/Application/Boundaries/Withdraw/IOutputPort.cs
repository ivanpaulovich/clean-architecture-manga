namespace Application.Boundaries.Withdraw
{
    /// <summary>
    /// Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<WithdrawOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Informs it is out of balance.
        /// </summary>
        /// <param name="message">Custom message.</param>
        void OutOfBalance(string message);
    }
}
