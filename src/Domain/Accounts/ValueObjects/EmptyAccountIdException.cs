// <copyright file="EmptyAccountIdException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    /// <summary>
    /// Empty Account Id Exception.
    /// </summary>
    public sealed class EmptyAccountIdException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyAccountIdException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }
    }
}
