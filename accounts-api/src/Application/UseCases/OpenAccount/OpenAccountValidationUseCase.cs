// <copyright file="OpenAccountValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount
{
    using System.Threading.Tasks;
    using Domain.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class OpenAccountValidationUseCase : IOpenAccountUseCase
    {
        private readonly IOpenAccountUseCase _useCase;
        private readonly Notification _notification;
        private IOutputPort _outputPort;

        public OpenAccountValidationUseCase(IOpenAccountUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new OpenAccountPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(decimal amount, string currency)
        {
            if (currency != Currency.Dollar.Code &&
                currency != Currency.Euro.Code &&
                currency != Currency.BritishPound.Code &&
                currency != Currency.Canadian.Code &&
                currency != Currency.Real.Code &&
                currency != Currency.Krona.Code)
            {
                this._notification
                    .Add(nameof(currency), "Currency is required.");
            }

            if (amount <= 0)
            {
                this._notification
                    .Add(nameof(amount), "Amount should be positive.");
            }

            if (this._notification
                .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(amount, currency)
                .ConfigureAwait(false);
        }
    }
}
