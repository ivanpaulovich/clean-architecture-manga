// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Deposit;

using Domain;
using Domain.Credits;

/// <summary>
///     Output Port.
/// </summary>
public interface IOutputPort
{
    /// <summary>
    ///     Invalid input.
    /// </summary>
    void Invalid();

    /// <summary>
    ///     Deposited.
    /// </summary>
    void Ok(Credit credit, Account account);

    /// <summary>
    ///     Not found.
    /// </summary>
    void NotFound();
}
