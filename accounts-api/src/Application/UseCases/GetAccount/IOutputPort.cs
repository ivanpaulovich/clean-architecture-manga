// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount;

using Domain;

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
    ///     Account closed.
    /// </summary>
    void NotFound();

    /// <summary>
    ///     Account closed.
    /// </summary>
    void Ok(Account account);
}
