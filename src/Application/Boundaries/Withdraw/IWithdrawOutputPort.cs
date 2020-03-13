// <copyright file="ICloseAccountGetAccountsOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Withdraw
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IWithdrawOutputPort
        : IOutputPortStandard<WithdrawOutput>, IOutputPortNotFound, IGetAccountsOutputPortError
    {
        /// <summary>
        ///     Informs it is out of balance.
        /// </summary>
        /// <param name="message">Custom message.</param>
        void OutOfBalance(string message);
    }
}
