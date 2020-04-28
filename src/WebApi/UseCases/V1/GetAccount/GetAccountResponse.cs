namespace WebApi.UseCases.V1.GetAccount
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     Get Account Details.
    /// </summary>
    public sealed class GetAccountResponse
    {
        public GetAccountResponse(AccountModel accountModel)
        {
            this.Account = accountModel;
        }

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public AccountModel Account { get; }
    }
}
