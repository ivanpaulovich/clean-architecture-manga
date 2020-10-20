// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Transfer
{
    using Domain;
    using Domain.Credits;
    using Domain.Debits;

    /// <summary>
    ///     Transfer Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();

        /// <summary>
        ///     Resource not found.
        /// </summary>
        void NotFound();

        /// <summary>
        /// </summary>
        /// <param name="originAccount"></param>
        /// <param name="debit"></param>
        /// <param name="destinationAccount"></param>
        /// <param name="credit"></param>
        void Ok(Account originAccount, Debit debit, Account destinationAccount, Credit credit);

        /// <summary>
        /// </summary>
        void OutOfFunds();
    }
}
