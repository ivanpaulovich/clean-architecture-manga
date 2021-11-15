// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount;

using Domain;

/// <summary>
///     Open Account Output Port.
/// </summary>
public interface IOutputPort
{
    /// <summary>
    ///     Account open.
    /// </summary>
    void Ok(Account account);

    /// <summary>
    ///     Resource not found.
    /// </summary>
    void NotFound();

    /// <summary>
    ///     Invalid input.
    /// </summary>
    void Invalid();
}
