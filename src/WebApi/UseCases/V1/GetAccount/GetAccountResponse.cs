namespace WebApi.UseCases.V1.GetAccount
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts;
    using ViewModels;

    /// <summary>
    ///     Get Account Response.
    /// </summary>
    public sealed class GetAccountResponse
    {
        /// <summary>
        ///     The Get Account Response constructor.
        /// </summary>
        public GetAccountResponse(IAccount account) => this.Account = new AccountDetailsModel(account);

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public AccountDetailsModel Account { get; }
    }
}
