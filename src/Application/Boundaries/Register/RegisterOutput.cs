// <copyright file="RegisterOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;

    /// <summary>
    ///     Register Output Message.
    /// </summary>
    public sealed class RegisterOutput
    {
        /// <summary>
        ///     <summary>
        ///         Initializes a new instance of the <see cref="RegisterOutput" /> class.
        ///     </summary>
        ///     <param name="user">User.</param>
        ///     <param name="customer">Customer object.</param>
        ///     <param name="accounts">Accounts list.</param>
        /// </summary>
        public RegisterOutput(
            IUser user,
            ICustomer customer,
            IList<IAccount> accounts)
        {
            if (accounts is null)
            {
                throw new ArgumentNullException(nameof(accounts));
            }

            this.User = user ?? throw new ArgumentNullException(nameof(user));
            this.Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            this.Accounts = new ReadOnlyCollection<IAccount>(accounts);
        }

        /// <summary>
        ///     Gets the User.
        /// </summary>
        public IUser User { get; }

        /// <summary>
        ///     Gets the Customer.
        /// </summary>
        public ICustomer Customer { get; }

        /// <summary>
        ///     Gets the Accounts.
        /// </summary>
        public IReadOnlyList<IAccount> Accounts { get; }
    }
}
