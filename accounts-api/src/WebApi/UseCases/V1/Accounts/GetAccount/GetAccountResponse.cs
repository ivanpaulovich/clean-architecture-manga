namespace WebApi.UseCases.V1.Accounts.GetAccount
{
    using Domain;
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     Get Account Response.
    /// </summary>
    public sealed class GetAccountResponse
    {
        /// <summary>
        ///     The Get Account Response constructor.
        /// </summary>
        public GetAccountResponse(Account account) => this.Account = new AccountDetailsModel(account);

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public AccountDetailsModel Account { get; }
    }
}
