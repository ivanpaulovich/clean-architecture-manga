// <copyright file="InvalidSSNException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers.ValueObjects
{
    /// <summary>
    /// InvalidSSNException.
    /// </summary>
    internal sealed class InvalidSSNException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSSNException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal InvalidSSNException(string message)
            : base(message)
        {
        }
    }
}
