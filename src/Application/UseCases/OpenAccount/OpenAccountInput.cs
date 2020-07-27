// <copyright file="OpenAccountInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount
{
    using Domain.Accounts.ValueObjects;
    using Services;

    /// <summary>
    ///     Open Account Input Message.
    /// </summary>
    public sealed class OpenAccountInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OpenAccountInput" /> class.
        /// </summary>
        public OpenAccountInput(decimal amount, string currency)
        {
            this.ModelState = new Notification();

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

        internal PositiveMoney Amount { get; }
        internal Notification ModelState { get; }
    }
}
