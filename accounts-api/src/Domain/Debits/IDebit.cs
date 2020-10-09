// <copyright file="IDebit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Debits
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
        Money Amount { get; }
    }
}
