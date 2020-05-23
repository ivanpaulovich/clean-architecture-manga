namespace WebApi.UseCases.V1.GetAccount
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts;
    using ViewModels;

    /// <summary>
    ///     Get Account Details.
    /// </summary>
    public sealed class GetAccountResponse
    {
        public GetAccountResponse(IAccount account) => this.Account = new AccountDetailsModel(account);

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public AccountDetailsModel Account { get; }
    }
}
