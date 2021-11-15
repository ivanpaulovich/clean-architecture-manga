// <copyright file="IDepositUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Deposit;

using System;
using System.Threading.Tasks;

/// <summary>
///     Deposit
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
///         Use
///         Case Domain-Driven Design Pattern
///     </see>
///     .
/// </summary>
public interface IDepositUseCase
{
    /// <summary>
    ///     Executes the Use Case.
    /// </summary>
    /// <param name="accountId">AccountId.</param>
    /// <param name="amount">Positive amount to deposit.</param>
    /// <param name="currency">Currency from amount.</param>
    /// <returns>Task.</returns>
    Task Execute(Guid accountId, decimal amount, string currency);

    /// <summary>
    ///     Sets the Output Port.
    /// </summary>
    /// <param name="outputPort">Output Port</param>
    void SetOutputPort(IOutputPort outputPort);
}
