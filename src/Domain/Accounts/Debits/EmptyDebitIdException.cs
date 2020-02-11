// <copyright file="EmptyDebitIdException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using System;

    /// <summary>
    ///     Empty DebitId Exception.
    /// </summary>
    public sealed class EmptyDebitIdException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmptyDebitIdException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal EmptyDebitIdException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public EmptyDebitIdException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EmptyDebitIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
