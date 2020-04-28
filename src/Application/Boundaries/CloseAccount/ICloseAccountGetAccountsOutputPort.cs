// <copyright file="ICloseAccountGetAccountsOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.CloseAccount
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface ICloseAccountGetAccountsOutputPort
        : IOutputPortStandard<CloseAccountOutput>, IOutputPortNotFound, IGetAccountsOutputPortError
    {
    }
}
