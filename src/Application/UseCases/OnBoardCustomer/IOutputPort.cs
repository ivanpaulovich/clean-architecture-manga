// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OnBoardCustomer
{
    using Domain.Customers;
    using Services;

    /// <summary>
    ///     OnBoard Customer Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid(Notification notification);

        /// <summary>
        ///     Customer on-boarded.
        /// </summary>
        void Ok(Customer customer);
    }
}
