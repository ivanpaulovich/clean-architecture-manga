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
        /// <summary>
        ///     Calculates the sum between positive amounts.
        /// </summary>
        /// <param name="amount">Positive amount.</param>
        /// <returns>The positive sum.</returns>
        PositiveMoney Sum(PositiveMoney amount);
    }
}
