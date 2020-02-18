// <copyright file="User.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess.Entities
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    ///     User.
    /// </summary>
    public class User : Domain.Security.User
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="customerId">CustomerId.</param>
        /// <param name="externalUserId">External User Id.</param>
        public User(CustomerId customerId, ExternalUserId externalUserId)
        {
            this.CustomerId = customerId;
            this.ExternalUserId = externalUserId;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        protected User()
        {
        }
    }
}
