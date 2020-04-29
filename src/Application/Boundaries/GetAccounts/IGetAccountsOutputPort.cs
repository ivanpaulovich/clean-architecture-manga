// <copyright file="IGetAccountsOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccounts
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IGetAccountsOutputPort
        : IOutputPortStandard<GetAccountsOutput>, IOutputPortError
    {
    }
}
