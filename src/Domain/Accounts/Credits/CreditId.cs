// <copyright file="CreditId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using System;

    /// <summary>
    /// CreditId <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">Value Object Domain-Driven Design Pattern</see>.
    /// </summary>
    public readonly struct CreditId
    {
        private readonly Guid creditId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditId"/> struct.
        /// </summary>
        /// <param name="creditId">CreditId.</param>
        public CreditId(Guid creditId)
        {
            if (creditId == Guid.Empty)
            {
                throw new EmptyCreditIdException($"{nameof(creditId)} cannot be empty.");
            }

            this.creditId = creditId;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return this.creditId.ToString();
        }

        /// <summary>
        /// Converts into Guid.
        /// </summary>
        /// <returns>Guid representation.</returns>
        public Guid ToGuid() => this.creditId;
    }
}
