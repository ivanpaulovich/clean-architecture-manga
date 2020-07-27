// <copyright file="IDepositOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Deposit
{
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Services;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid(Notification notification);

        /// <summary>
        ///     Deposited.
        /// </summary>
        void Ok(Credit credit, Account account);

        /// <summary>
        ///     Not found.
        /// </summary>
        void NotFound();
    }
}
