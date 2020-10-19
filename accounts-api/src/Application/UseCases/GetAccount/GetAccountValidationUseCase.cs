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
        private readonly Notification _notification;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountValidationUseCase" /> class.
        /// </summary>
        public GetAccountValidationUseCase(IGetAccountUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new GetAccountPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                this._notification
                    .Add(nameof(accountId), "AccountId is required.");
            }

            if (this._notification
                .IsInvalid)
            {
                this._outputPort.Invalid();
                return;
            }

            await this._useCase
                .Execute(accountId)
                .ConfigureAwait(false);
        }
    }
}
