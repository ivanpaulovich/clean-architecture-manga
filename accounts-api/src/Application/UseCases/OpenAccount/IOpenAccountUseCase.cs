// <copyright file="IOpenAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount;

using System.Threading.Tasks;

/// <summary>
///     Open Account
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
///         Use
///         Case Domain-Driven Design Pattern
///     </see>
///     .
/// </summary>
public interface IOpenAccountUseCase
{
    /// <summary>
    ///     Executes the Use Case
    /// </summary>
    Task Execute(decimal amount, string currency);

    /// <summary>
    ///     Sets the Output Port.
    /// </summary>
    /// <param name="outputPort">Output Port</param>
    void SetOutputPort(IOutputPort outputPort);
}
