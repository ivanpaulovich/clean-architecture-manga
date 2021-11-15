namespace WebApi.UseCases.V1.Transactions.Deposit;

using System.ComponentModel.DataAnnotations;
using ViewModels;

/// <summary>
///     The response for a successful Deposit.
/// </summary>
public sealed class DepositResponse
{
    /// <summary>
    ///     The Deposit response constructor.
    /// </summary>
    public DepositResponse(CreditModel transaction) => this.Transaction = transaction;

    /// <summary>
    ///     Gets Transaction.
    /// </summary>
    [Required]
    public CreditModel Transaction { get; }
}
