// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using Common;
    using ValueObjects;

    /// <inheritdoc />
    public abstract class Customer : ICustomer
    {
        /// <summary>
        ///     Gets or sets First Name.
        /// </summary>
        public Name FirstName { get; set; }

        /// <summary>
        ///     Gets or sets Last Name.
        /// </summary>
        public Name LastName { get; set; }

        /// <summary>
        ///     Gets or sets SSN.
        /// </summary>
        public SSN SSN { get; set; }

        /// <inheritdoc />
        public abstract CustomerId CustomerId { get; }

        /// <inheritdoc />
        public abstract AccountCollection Accounts { get; }

        /// <inheritdoc />
        public void Update(SSN ssn, Name firstName, Name lastName)
        {
            this.SSN = ssn;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
