// <copyright file="WithdrawInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw
{
    using Domain.ValueObjects;
    using Services;
    using System;

    /// <summary>
    ///     Withdraw Input Message.
    /// </summary>
    internal sealed class WithdrawInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WithdrawInput" /> class.
        /// </summary>
        internal WithdrawInput(Guid accountId, decimal amount, string currency)
        {
            this.ModelState = new Notification();

            if (accountId != Guid.Empty)
            {
                this.AccountId = new AccountId(accountId);
            }
            else
            {
                this.ModelState.Add(nameof(accountId), "AccountId is required.");
            }

            if (currency == Currency.Dollar.Code ||
                currency == Currency.Euro.Code ||
                currency == Currency.BritishPound.Code ||
                currency == Currency.Canadian.Code ||
                currency == Currency.Real.Code ||
                currency == Currency.Krona.Code)
            {
                if (amount > 0)
                {
                    this.Amount = new PositiveMoney(amount, new Currency(currency));
                }
                else
                {
                    this.ModelState.Add(nameof(amount), "Amount should be positive.");
                }
            }
            else
            {
                this.ModelState.Add(nameof(currency), "Currency is required.");
            }
        }

        internal AccountId AccountId { get; }
        internal PositiveMoney Amount { get; }
        internal Notification ModelState { get; }
    }
}
