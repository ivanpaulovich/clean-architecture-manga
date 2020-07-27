// <copyright file="TransferInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Transfer
{
    using System;
    using Domain.Accounts.ValueObjects;
    using Services;

    /// <summary>
    ///     Transfer Input Message.
    /// </summary>
    public sealed class TransferInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferInput" /> class.
        /// </summary>
        public TransferInput(Guid originAccountId, Guid destinationAccountId, decimal amount, string currency)
        {
            this.ModelState = new Notification();

            if (originAccountId != Guid.Empty)
            {
                this.OriginAccountId = new AccountId(originAccountId);
            }
            else
            {
                this.ModelState.Add(nameof(originAccountId), "Origin AccountId is required.");
            }

            if (destinationAccountId != Guid.Empty)
            {
                this.DestinationAccountId = new AccountId(destinationAccountId);
            }
            else
            {
                this.ModelState.Add(nameof(destinationAccountId), "Destination AccountId is required.");
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
                    this.TransferAmount = new PositiveMoney(amount, new Currency(currency));
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

        internal AccountId OriginAccountId { get; }
        internal AccountId DestinationAccountId { get; }
        internal PositiveMoney TransferAmount { get; }
        internal Notification ModelState { get; }
    }
}
