// <copyright file="IDebit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using ValueObjects;

    /// <summary>
    ///     Debit.
    /// </summary>
    public interface IDebit
    {
        /// <summary>
        ///     Calculates the sum of two positive amounts.
        /// </summary>
        /// <param name="amount">Positive amount.</param>
        /// <returns>The sum.</returns>
        PositiveMoney Sum(PositiveMoney amount);
    }
}
