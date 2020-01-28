namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    /// AccountId <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct AccountId
    {
        private readonly Guid _accountId;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountId"/> struct.
        /// </summary>
        /// <param name="accountId">AccountId Guid.</param>
        public AccountId(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new EmptyAccountIdException($"{nameof(accountId)} cannot be empty.");
            }

            this._accountId = accountId;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return this._accountId.ToString();
        }

        /// <summary>
        /// Converts into Guid.
        /// </summary>
        /// <returns>Guid representation.</returns>
        public Guid ToGuid() => this._accountId;
    }
}
