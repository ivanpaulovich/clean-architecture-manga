// <copyright file="SSN.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers.ValueObjects
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    ///     SSN
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct SSN : IEquatable<SSN>
    {
        private const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        private readonly string text;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SSN" /> struct.
        /// </summary>
        /// <param name="text">SSN.</param>
        public SSN(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new SSNShouldNotBeEmptyException(Messages.TheTextFieldIsRequired);
            }

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(text);

            if (!match.Success)
            {
                throw new InvalidSSNException(Messages.InvalidTextFormat);
            }

            this.text = text;
        }

        /// <summary>
        ///     Converts into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString() => this.text;

        /// <summary>
        ///     Equals.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>True when equals.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SSN ssnObj)
            {
                return this.Equals(ssnObj);
            }

            return false;
        }

        /// <summary>
        ///     Get Hash Code.
        /// </summary>
        /// <returns>Hash Code.</returns>
        public override int GetHashCode()
        {
            return this.text.GetHashCode(StringComparison.InvariantCulture);
        }

        /// <summary>
        ///     Equals.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>True if equals.</returns>
        public static bool operator ==(SSN left, SSN right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Different.
        /// </summary>
        /// <param name="left">Left object.</param>
        /// <param name="right">Right object.</param>
        /// <returns>True if different.</returns>
        public static bool operator !=(SSN left, SSN right)
        {
            return !(left == right);
        }

        /// <summary>
        ///     Equals.
        /// </summary>
        /// <param name="other">Other object.</param>
        /// <returns>True if equals.</returns>
        public bool Equals(SSN other)
        {
            return string.Compare(this.text, other.text, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
