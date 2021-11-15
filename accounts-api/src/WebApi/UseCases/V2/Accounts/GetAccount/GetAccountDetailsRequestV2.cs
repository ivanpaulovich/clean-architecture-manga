namespace WebApi.UseCases.V2.Accounts.GetAccount;

using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
///     The Get Account Details Request.
/// </summary>
public sealed class GetAccountDetailsRequestV2
{
    /// <summary>
    ///     Gets or sets account ID.
    /// </summary>
    [Required]
    public Guid AccountId { get; set; }
}
