// <copyright file="ExternalUserIdShouldNotBeEmptyException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security.ValueObjects
{
    /// <summary>
    /// External User Id Should Not Be Empty Exception.
    /// </summary>
    public sealed class ExternalUserIdShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalUserIdShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal ExternalUserIdShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
