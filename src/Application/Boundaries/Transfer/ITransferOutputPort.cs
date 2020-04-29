// <copyright file="ITransferOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Transfer
{
    /// <summary>
    ///     Transfer Output Port.
    /// </summary>
    public interface ITransferOutputPort
        : IOutputPortStandard<TransferOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
