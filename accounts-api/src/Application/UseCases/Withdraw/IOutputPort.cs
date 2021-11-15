// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw;

using Domain;
using Domain.Debits;

/// <summary>
///     Output Port.
/// </summary>
public interface IOutputPort
{
    /// <summary>
    ///     Informs it is out of balance.
    /// </summary>
    void OutOfFunds();

    /// <summary>
    ///     Invalid input.
    /// </summary>
    void Invalid();

    /// <summary>
    ///     Resource not closed.
    /// </summary>
    void NotFound();

    /// <summary>
    ///     Withdraw success.
    /// </summary>
    /// <param name="debit">Debit Transaction.</param>
    /// <param name="account">Account Transaction</param>
    void Ok(Debit debit, Account account);
}
