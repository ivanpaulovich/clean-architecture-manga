// <copyright file="ICloseAccountGetAccountsOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Deposit
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IDepositGetAccountsOutputPort
        : IOutputPortStandard<DepositOutput>, IOutputPortNotFound, IGetAccountsOutputPortError
    {
    }
}
