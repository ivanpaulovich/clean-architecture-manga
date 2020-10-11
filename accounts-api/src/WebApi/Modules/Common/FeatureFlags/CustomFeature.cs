namespace WebApi.Modules.Common.FeatureFlags
{
    /// <summary>
    ///     Features Flags Enum.
    /// </summary>
    public enum CustomFeature
    {
        /// <summary>
        ///     Close Account.
        /// </summary>
        CloseAccount,

        /// <summary>
        ///     Deposit.
        /// </summary>
        Deposit,

        /// <summary>
        ///     Get Account.
        /// </summary>
        GetAccount,

        /// <summary>
        ///     Get Accounts.
        /// </summary>
        GetAccounts,

        /// <summary>
        ///     Open Account.
        /// </summary>
        OpenAccount,

        /// <summary>
        ///     Transfer Feature.
        /// </summary>
        Transfer,

        /// <summary>
        ///     Withdraw.
        /// </summary>
        Withdraw,

        /// <summary>
        ///     Get Account V2.
        /// </summary>
        GetAccountV2,

        /// <summary>
        ///     Filter errors out.
        /// </summary>
        ErrorFilter,

        /// <summary>
        ///     Use Swagger.
        /// </summary>
        Swagger,

        /// <summary>
        ///     Use SQL Server Persistence.
        /// </summary>
        SQLServer,

        /// <summary>
        ///     Uses external exchange service.
        /// </summary>
        CurrencyExchange,

        /// <summary>
        ///     Use authentication.
        /// </summary>
        Authentication
    }
}
