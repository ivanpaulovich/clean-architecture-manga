// <copyright file="Name.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers.ValueObjects
{
    using System;

    /// <summary>
    ///     Name
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct Name : IEquatable<Name>
    {
        private readonly string _text;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Name" /> struct.
        /// </summary>
        /// <param name="text">Name.</param>
        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException(Messages.TheTextFieldIsRequired);
            }

            this._text = text;
        }

        /// <summary>
        ///     Converts into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString() => this._text;

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Name nameObj)
            {
                return this.Equals(nameObj);
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
        public static bool operator ==(Name left, Name right) => left.Equals(right);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Name left, Name right) => !(left == right);

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Name other) => this._text == other._text;
    }
}
