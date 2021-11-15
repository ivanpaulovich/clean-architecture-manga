// <copyright file="WithdrawValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw;

using System;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Services;

/// <inheritdoc />
public sealed class WithdrawValidationUseCase : IWithdrawUseCase
{
    private readonly Notification _notification;
    private readonly IWithdrawUseCase _useCase;
    private IOutputPort _outputPort;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WithdrawValidationUseCase" /> class.
    /// </summary>
    public WithdrawValidationUseCase(IWithdrawUseCase useCase, Notification notification)
    {
        this._useCase = useCase;
        this._notification = notification;
        this._outputPort = new WithdrawPresenter();
    }

    /// <inheritdoc />
    public void SetOutputPort(IOutputPort outputPort)
    {
        this._outputPort = outputPort;
        this._useCase.SetOutputPort(outputPort);
    }

    /// <inheritdoc />
    public async Task Execute(Guid accountId, decimal amount, string currency)
    {
        if (accountId == Guid.Empty)
        {
            this._notification
                .Add(nameof(accountId), "AccountId is required.");
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
            this._outputPort?
                .Invalid();
            return;
        }

        await this._useCase
            .Execute(accountId, amount, currency)
            .ConfigureAwait(false);
    }
}
