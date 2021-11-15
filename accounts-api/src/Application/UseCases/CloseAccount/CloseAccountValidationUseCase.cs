// <copyright file="CloseAccountValidationUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.CloseAccount;

using System;
using System.Threading.Tasks;
using Services;

/// <inheritdoc />
public sealed class CloseAccountValidationUseCase : ICloseAccountUseCase
{
    private readonly Notification _notification;
    private readonly ICloseAccountUseCase _useCase;
    private IOutputPort _outputPort;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CloseAccountValidationUseCase" /> class.
    /// </summary>
    public CloseAccountValidationUseCase(ICloseAccountUseCase useCase, Notification notification)
    {
        this._useCase = useCase;
        this._notification = notification;
        this._outputPort = new CloseAccountPresenter();
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

        if (!this._notification
            .IsValid)
        {
            this._outputPort
                .Invalid();
            return;
        }

        await this._useCase
            .Execute(accountId)
            .ConfigureAwait(false);
    }
}
