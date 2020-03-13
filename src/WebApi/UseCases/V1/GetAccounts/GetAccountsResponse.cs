namespace WebApi.UseCases.V1.GetAccounts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts;
    using ViewModels;

    /// <summary>
    ///     Get Account Details.
    /// </summary>
    public sealed class GetAccountsResponse
    {
        public GetAccountsResponse(IEnumerable<IAccount> accounts)
        {
            foreach (IAccount account in accounts)
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
