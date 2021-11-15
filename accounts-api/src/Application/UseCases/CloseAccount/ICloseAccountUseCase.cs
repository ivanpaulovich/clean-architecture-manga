// <copyright file="ICloseAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.CloseAccount;

using System;
using System.Threading.Tasks;

/// <summary>
///     Close Account
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
///         Use
///         Case Domain-Driven Design Pattern
///     </see>
///     .
/// </summary>
public interface ICloseAccountUseCase
{
    /// <summary>
    ///     Executes the use case.
    /// </summary>
    /// <param name="accountId">Account Id.</param>
    /// <returns>Task.</returns>
    Task Execute(Guid accountId);

    /// <summary>
    ///     Sets the Output Port.
    /// </summary>
    /// <param name="outputPort">Output Port</param>
    void SetOutputPort(IOutputPort outputPort);
}
