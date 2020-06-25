// <copyright file="CurrencyNotFoundException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     Currency Not FoundException.
    /// </summary>
    public sealed class CurrencyNotAllowedException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CurrencyNotAllowedException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal CurrencyNotAllowedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public CurrencyNotAllowedException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public CurrencyNotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
