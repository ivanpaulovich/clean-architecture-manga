// <copyright file="TransferValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Transfer;

using System;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Services;

/// <inheritdoc />
public sealed class TransferValidationUseCase : ITransferUseCase
{
    private readonly Notification _notification;
    private readonly ITransferUseCase _useCase;
    private IOutputPort _outputPort;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TransferUseCase" /> class.
    /// </summary>
    public TransferValidationUseCase(ITransferUseCase useCase, Notification notification)
    {
        this._useCase = useCase;
        this._notification = notification;
        this._outputPort = new TransferPresenter();
    }

    /// <inheritdoc />
    public void SetOutputPort(IOutputPort outputPort)
    {
        this._outputPort = outputPort;
        this._useCase.SetOutputPort(outputPort);
    }

    /// <inheritdoc />
    public async Task Execute(Guid originAccountId, Guid destinationAccountId, decimal amount, string currency)
    {
        if (originAccountId == Guid.Empty)
        {
            this._notification
                .Add(nameof(originAccountId), "AccountId is required.");
        }

        if (destinationAccountId == Guid.Empty)
        {
            this._notification
                .Add(nameof(destinationAccountId), "AccountId is required.");
        }

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
            .Execute(originAccountId, destinationAccountId, amount, currency)
            .ConfigureAwait(false);
    }
}
