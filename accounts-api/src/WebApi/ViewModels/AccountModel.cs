namespace WebApi.ViewModels;

using System;
using System.ComponentModel.DataAnnotations;
using Domain;

/// <summary>
///     Account Details.
/// </summary>
public sealed class AccountModel
{
    /// <summary>
    ///     Account Details constructor.
    /// </summary>
    public AccountModel(Account account)
    {
        this.AccountId = account.AccountId.Id;
        this.CurrentBalance = account
            .GetCurrentBalance()
            .Amount;
        this.Currency = account.Currency.Code;
    }

    /// <summary>
    ///     Gets account ID.
    /// </summary>
    [Required]
    public Guid AccountId { get; }

    /// <summary>
    ///     Gets current Balance.
    /// </summary>
    [Required]
    public decimal CurrentBalance { get; }

    /// <summary>
    ///     Gets current Balance.
    /// </summary>
    [Required]
    public string Currency { get; }
}
