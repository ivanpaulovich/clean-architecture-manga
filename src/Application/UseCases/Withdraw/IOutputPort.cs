// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw
{
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Services;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Informs it is out of balance.
        /// </summary>
        void OutOfFunds();

        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid(Notification notification);

        /// <summary>
        ///     Resource not closed.
        /// </summary>
        void NotFound();

        /// <summary>
        /// </summary>
        /// <param name="debit"></param>
        /// <param name="account"></param>
        void Ok(Debit debit, Account account);
    }
}
