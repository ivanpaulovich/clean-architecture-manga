// <copyright file="IDepositOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Deposit
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IDepositOutputPort
        : IOutputPortStandard<DepositOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
