// <copyright file="CustomerNotFoundException.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using System;

    /// <summary>
    ///     Customer Not Found Exception.
    /// </summary>
    public sealed class CustomerNotFoundException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomerNotFoundException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CustomerNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public CustomerNotFoundException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public CustomerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
