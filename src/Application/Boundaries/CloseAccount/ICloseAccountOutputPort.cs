// <copyright file="ICloseAccountOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.CloseAccount
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface ICloseAccountOutputPort
        : IOutputPortStandard<CloseAccountOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
