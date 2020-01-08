namespace Application.Boundaries.CloseAccount
{
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Close Account Output Message.
    /// </summary>
    public sealed class CloseAccountOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloseAccountOutput"/> class.
        /// </summary>
        /// <param name="account">IAccount object.</param>
        public CloseAccountOutput(IAccount account)
        {
            this.AccountId = account.Id;
        }

        /// <summary>
        /// Gets AccountId.
        /// </summary>
        public AccountId AccountId { get; }
    }
}
