// <copyright file="GetCustomerOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetCustomer
{
    using System;
    using Domain.Customers;

    /// <summary>
    ///     Gets Customer Details Output Message.
    /// </summary>
    public sealed class GetCustomerOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetCustomerOutput" /> class.
        /// </summary>
        /// <param name="customer">Customer object.</param>
        public GetCustomerOutput(ICustomer customer) =>
            this.Customer = customer ?? throw new ArgumentNullException(nameof(customer));

        /// <summary>
        ///     Gets the Customer.
        /// </summary>
        public ICustomer Customer { get; }
    }
}
