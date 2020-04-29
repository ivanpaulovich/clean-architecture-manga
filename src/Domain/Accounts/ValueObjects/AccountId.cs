// <copyright file="AccountId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     AccountId
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct AccountId : IEquatable<AccountId>
    {
        private readonly Guid _accountId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountId" /> struct.
        /// </summary>
        /// <param name="accountId">AccountId Guid.</param>
        public AccountId(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new EmptyAccountIdException(Messages.AccountIdCannotBeEmpty);
            }

            this._accountId = accountId;
        }

        /// <summary>
        ///     Converts into string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() => this._accountId.ToString();

        /// <summary>
        ///     Converts into Guid.
        /// </summary>
        /// <returns>Guid representation.</returns>
        public Guid ToGuid() => this._accountId;

        /// <summary>
        ///     Check if objects are equals.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>Returns true when equals.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AccountId accountIdObj)
            {
                return this.Equals(accountIdObj);
            }

            return false;
        }

        /// <summary>
        ///     Get Hash Code.
        /// </summary>
        /// <returns>Hash Code.</returns>
        public override int GetHashCode() => this._accountId.GetHashCode();

        /// <summary>
        ///     Checks if other object is equals.
        /// </summary>
        /// <param name="other">Other AccountId.</param>
        /// <returns>True if equals.</returns>
        public bool Equals(AccountId other) => this._accountId == other._accountId;

        /// <summary>
        ///     Equals.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>True if equals.</returns>
        public static bool operator ==(AccountId left, AccountId right) => left.Equals(right);

        /// <summary>
        ///     Different.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>True if different.</returns>
        public static bool operator !=(AccountId left, AccountId right) => !(left == right);
    }
}
