// <copyright file="IGetAccountsUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccounts;

using System.Threading.Tasks;

/// <summary>
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
///         Use
///         Case Domain-Driven Design Pattern
///     </see>
///     .
/// </summary>
public interface IGetAccountsUseCase
{
    /// <summary>
    ///     Executes the use case.
    /// </summary>
    /// <returns>Task.</returns>
    Task Execute();

    /// <summary>
    ///     Sets the Output Port.
    /// </summary>
    /// <param name="outputPort">Output Port</param>
    void SetOutputPort(IOutputPort outputPort);
}
