// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetCustomerDetails
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<GetCustomerDetailsOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
