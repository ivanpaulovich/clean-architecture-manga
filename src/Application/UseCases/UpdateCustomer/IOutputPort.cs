// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.UpdateCustomer
{
    using Domain.Customers;
    using Services;

    /// <summary>
    ///     Update Customer Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid(Notification notification);

        /// <summary>
        ///     Customer updated successfully.
        /// </summary>
        void Ok(Customer customer);

        /// <summary>
        ///     Customer not found.
        /// </summary>
        void NotFound();
    }
}
