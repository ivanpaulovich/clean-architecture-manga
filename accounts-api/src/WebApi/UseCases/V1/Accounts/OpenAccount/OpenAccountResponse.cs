namespace WebApi.UseCases.V1.Accounts.OpenAccount;

using System.ComponentModel.DataAnnotations;
using ViewModels;

/// <summary>
///     The response for Registration.
/// </summary>
public sealed class OpenAccountResponse
{
    /// <summary>
    ///     The Response Registration Constructor.
    /// </summary>
    public OpenAccountResponse(AccountModel accountModel) => this.Account = accountModel;

    /// <summary>
    ///     Gets customer.
    /// </summary>
    [Required]
    public AccountModel Account { get; }
}
