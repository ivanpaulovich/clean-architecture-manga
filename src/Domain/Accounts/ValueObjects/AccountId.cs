// <copyright file="AccountId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    /// AccountId <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct AccountId
    {
        private readonly Guid accountId;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountId"/> struct.
        /// </summary>
        /// <param name="accountId">AccountId Guid.</param>
        public AccountId(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new EmptyAccountIdException(
                    $"{nameof(accountId)} cannot be empty.");
            }

            this.accountId = accountId;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return this.accountId.ToString();
        }

        /// <summary>
        /// Converts into Guid.
        /// </summary>
        /// <returns>Guid representation.</returns>
        public Guid ToGuid() => this.accountId;

        /// <summary>
        /// Check if objects are equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Returns true when equals.</returns>
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AccountId left, AccountId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AccountId left, AccountId right)
        {
            return !(left == right);
        }
    }
}
