namespace WebApi.UseCases.V1.Accounts.GetAccounts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts;
    using ViewModels;

    /// <summary>
    ///     Get Accounts Response.
    /// </summary>
    public sealed class GetAccountsResponse
    {
        /// <summary>
        ///     The Get Accounts Response constructor.
        /// </summary>
        public GetAccountsResponse(IEnumerable<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                var accountModel = new AccountModel(account);
                this.Accounts.Add(accountModel);
            }
        }

        /// <summary>
        ///     Accounts
        /// </summary>
        [Required]
        public List<AccountModel> Accounts { get; } = new List<AccountModel>();
    }
}
