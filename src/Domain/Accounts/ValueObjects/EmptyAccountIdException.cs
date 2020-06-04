// <copyright file="EmptyAccountIdException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     Empty Account Id Exception.
    /// </summary>
    public sealed class EmptyAccountIdException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmptyAccountIdException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public EmptyAccountIdException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EmptyAccountIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
