// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccountDetails
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<GetAccountDetailsOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
