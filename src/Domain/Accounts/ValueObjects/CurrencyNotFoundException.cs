// <copyright file="CurrencyNotFoundException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     Currency Not FoundException.
    /// </summary>
    public sealed class CurrencyNotFoundException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CurrencyNotFoundException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal CurrencyNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public CurrencyNotFoundException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public CurrencyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
