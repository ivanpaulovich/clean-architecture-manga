// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetCustomer
{
    using Domain.Customers;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Customer.
        /// </summary>
        void Ok(Customer customer);

        /// <summary>
        ///     Customer not found.
        /// </summary>
        void NotFound();
    }
}
