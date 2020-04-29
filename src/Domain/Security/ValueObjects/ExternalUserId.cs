// <copyright file="ExternalUserId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security.ValueObjects
{
    using System;

    /// <summary>
    ///     ExternalUserId
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct ExternalUserId : IEquatable<ExternalUserId>
    {
        private readonly string _text;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExternalUserId" /> struct.
        /// </summary>
        /// <param name="text">External User Id.</param>
        public ExternalUserId(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ExternalUserIdShouldNotBeEmptyException(Messages.TheTextFieldIsRequired);
            }

            this._text = text;
        }

        /// <summary>
        ///     Converts into string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() => this._text;

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is ExternalUserId externalUserIdObj)
            {
                return this.Equals(externalUserIdObj);
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => this._text.GetHashCode(StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ExternalUserId left, ExternalUserId right) => left.Equals(right);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ExternalUserId left, ExternalUserId right) => !(left == right);

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ExternalUserId other) => this._text == other._text;
    }
}
