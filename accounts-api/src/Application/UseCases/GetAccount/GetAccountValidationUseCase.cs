// <copyright file="GetAccountValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount
{
    using Application.Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetAccountValidationUseCase : IGetAccountUseCase
    {
        private readonly IGetAccountUseCase _useCase;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountValidationUseCase" /> class.
        /// </summary>
        public GetAccountValidationUseCase(IGetAccountUseCase useCase)
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
        public Task Execute(Guid accountId)
        {
            var modelState = new Notification();

            if (accountId == Guid.Empty)
            {
                modelState.Add(nameof(accountId), "AccountId is required.");
            }

            if (modelState.IsValid)
            {
                return this._useCase
                    .Execute(accountId);
            }

            this._outputPort?
                .Invalid(modelState);

            return Task.CompletedTask;
        }
    }
}
