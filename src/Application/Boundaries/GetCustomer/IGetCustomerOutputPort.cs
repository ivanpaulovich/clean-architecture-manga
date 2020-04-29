// <copyright file="IGetCustomerOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetCustomer
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IGetCustomerOutputPort
        : IOutputPortStandard<GetCustomerOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
