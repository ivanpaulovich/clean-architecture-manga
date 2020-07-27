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
        DebitId DebitId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        PositiveMoney Amount { get; }
    }
}
