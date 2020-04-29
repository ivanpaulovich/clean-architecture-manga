// <copyright file="IGetAccountOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccount
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IGetAccountOutputPort
        : IOutputPortStandard<GetAccountOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
