// <copyright file="CreditId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using System;

    /// <summary>
    ///     CreditId
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">
    ///         Value
    ///         Object Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct CreditId : IEquatable<CreditId>
    {
        private readonly Guid _creditId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreditId" /> struct.
        /// </summary>
        /// <param name="creditId">CreditId.</param>
        public CreditId(Guid creditId)
        {
            if (creditId == Guid.Empty)
            {
                throw new EmptyCreditIdException(Messages.CreditIdCannotBeEmpty);
            }

            this._creditId = creditId;
        }

        /// <summary>
        ///     Converts into string.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString() => this._creditId.ToString();

        /// <summary>
        ///     Converts into Guid.
        /// </summary>
        /// <returns>Guid representation.</returns>
        public Guid ToGuid() => this._creditId;

        /// <summary>
        ///     Equals.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>True if equals.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CreditId creditIdObj)
            {
                return this.Equals(creditIdObj);
            }

            return false;
        }

        /// <summary>
        ///     Returns the Hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode() => this._creditId.GetHashCode();

        /// <summary>
        ///     Equals operator.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>True if equals.</returns>
        public static bool operator ==(CreditId left, CreditId right) => left.Equals(right);

        /// <summary>
        ///     Is different.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>True if different.</returns>
        public static bool operator !=(CreditId left, CreditId right) => !(left == right);

        /// <summary>
        ///     True if equals.
        /// </summary>
        /// <param name="other">Other object.</param>
        /// <returns>True if equals.</returns>
        public bool Equals(CreditId other) => this._creditId == other._creditId;
    }
}
