// <copyright file="EmptyCreditIdException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using System;

    /// <summary>
    ///     Empty CreditId Exception.
    /// </summary>
    public sealed class EmptyCreditIdException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmptyCreditIdException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal EmptyCreditIdException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public EmptyCreditIdException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public EmptyCreditIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
