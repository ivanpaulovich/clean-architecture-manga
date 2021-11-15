// <copyright file="Credit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Credits;

using System;
using ValueObjects;

/// <summary>
///     Credit
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
///         Entity
///         Design Pattern
///     </see>
///     .
/// </summary>
public class Credit : ICredit
{
    public Credit(CreditId creditId, AccountId accountId, DateTime transactionDate, decimal value, string currency)
    {
        this.CreditId = creditId;
        this.AccountId = accountId;
        this.TransactionDate = transactionDate;
        this.Amount = new Money(value, new Currency(currency));
    }

    /// <summary>
    ///     Gets Description.
    /// </summary>
    public static string Description => "Credit";

    /// <summary>
    ///     Gets or sets Transaction Date.
    /// </summary>
    public DateTime TransactionDate { get; }

    /// <summary>
    ///     Gets or sets AccountId.
    /// </summary>
    public AccountId AccountId { get; }

    public Account? Account { get; set; }

    public decimal Value => this.Amount.Amount;

    public string Currency => this.Amount.Currency.Code;

    /// <summary>
    ///     Gets or sets Id.
    /// </summary>
    public CreditId CreditId { get; }

    /// <summary>
    ///     Gets or sets Amount.
    /// </summary>
    public Money Amount { get; }

    /// <summary>
    ///     Calculate the sum of positive amounts.
    /// </summary>
    /// <param name="amount">Positive amount.</param>
    /// <returns>The positive sum.</returns>
    public Money Sum(Money amount) => this.Amount.Add(amount);
}
