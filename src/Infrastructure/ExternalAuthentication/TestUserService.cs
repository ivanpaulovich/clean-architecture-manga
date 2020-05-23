// <copyright file="TestUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.ExternalAuthentication
{
    using DataAccess;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;

    /// <inheritdoc />
    public sealed class TestUserService : IUserService
    {
        private readonly IUserFactory _userFactory;

        /// <summary>
        /// </summary>
        /// <param name="userFactory"></param>
        public TestUserService(IUserFactory userFactory) => this._userFactory = userFactory;

        /// <inheritdoc />
        public IUser GetUser()
        {
            CustomerId customerId = new CustomerId(MangaContextFake.DefaultCustomerId.ToGuid());
            ExternalUserId externalUserId = new ExternalUserId(Messages.ExternalUserID);
            Name name = new Name(Messages.UserName);

            IUser user = this._userFactory
                .NewUser(customerId, externalUserId, name);
            return user;
        }
    }
}
