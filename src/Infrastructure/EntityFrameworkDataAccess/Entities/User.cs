// <copyright file="User.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public class User : Domain.Security.User
    {
        public User(CustomerId customerId, ExternalUserId externalUserId)
        {
            CustomerId = customerId;
            ExternalUserId = externalUserId;
        }

        protected User()
        {
        }
    }
}
