// <copyright file="DebitsCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Debits;

using System.Collections.Generic;
using System.Linq;
using ValueObjects;

/// <summary>
///     Debits
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">
///         First-Class
///         Collection Design Pattern
///     </see>
///     .
/// </summary>
public sealed class DebitsCollection : List<Debit>
{
    /// <summary>
    ///     Gets Total amount.
    /// </summary>
    /// <returns>Total.</returns>
    public Money GetTotal()
    {
        if (this.Count == 0)
        {
            return new Money(0, new Currency(string.Empty));
        }

        Money total = new Money(0, this.First().Amount.Currency);

        return this.Aggregate(total, (current, credit) =>
            new Money(current.Amount + credit.Amount.Amount, current.Currency));
    }
}
