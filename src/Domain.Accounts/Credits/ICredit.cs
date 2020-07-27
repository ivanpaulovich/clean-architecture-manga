// <copyright file="ICredit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using ValueObjects;

    /// <summary>
    ///     Credit Entity Interface.
    /// </summary>
    public interface ICredit
    {
        CreditId CreditId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        PositiveMoney Amount { get; }
    }
}
