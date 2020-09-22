// <copyright file="TransferValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Transfer
{
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class TransferValidationUseCase : ITransferUseCase
    {
        private readonly ITransferUseCase _useCase;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferUseCase" /> class.
        /// </summary>
        public TransferValidationUseCase(ITransferUseCase transferUseCase)
        {
            this._useCase = transferUseCase;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public Task Execute(Guid originAccountId, Guid destinationAccountId, decimal amount, string currency)
        {
            var modelState = new Notification();

            if (originAccountId == Guid.Empty)
            {
                modelState.Add(nameof(originAccountId), "AccountId is required.");
            }

            if (destinationAccountId == Guid.Empty)
            {
                modelState.Add(nameof(destinationAccountId), "AccountId is required.");
            }

            if (currency != Currency.Dollar.Code &&
                currency != Currency.Euro.Code &&
                currency != Currency.BritishPound.Code &&
                currency != Currency.Canadian.Code &&
                currency != Currency.Real.Code &&
                currency != Currency.Krona.Code)
            {
                modelState.Add(nameof(currency), "Currency is required.");
            }

            if (amount <= 0)
            {
                modelState.Add(nameof(amount), "Amount should be positive.");
            }

            if (modelState.IsValid)
            {
                return this._useCase
                    .Execute(originAccountId, destinationAccountId, amount, currency);
            }

            this._outputPort?
                .Invalid(modelState);

            return Task.CompletedTask;
        }
    }
}
