// <copyright file="OpenAccountValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount
{
    using Domain.ValueObjects;
    using Services;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class OpenAccountValidationUseCase : IOpenAccountUseCase
    {
        private readonly IOpenAccountUseCase _useCase;
        private IOutputPort? _outputPort;

        public OpenAccountValidationUseCase(
            IOpenAccountUseCase useCase)
        {
            this._useCase = useCase;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public Task Execute(decimal amount, string currency)
        {
            var modelState = new Notification();

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
                    .Execute(amount, currency);
            }

            this._outputPort?
                .Invalid(modelState);

            return Task.CompletedTask;
        }
    }
}
