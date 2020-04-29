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

    public sealed class TestUserService : IUserService
    {
        private readonly IUserFactory _userFactory;

        /// <summary>
        ///
        /// </summary>
        /// <param name="userFactory"></param>
        public TestUserService(IUserFactory userFactory)
        {
            this._userFactory = userFactory;
        }

        public IUser GetUser()
        {
            var customerId = new CustomerId(MangaContextFake.DefaultCustomerId.ToGuid());
            var externalUserId = new ExternalUserId("github/ivanpaulovich");
            var name = new Name("Ivan Paulovich");

            var user = this._userFactory
                .NewUser(customerId, externalUserId, name);
            return user;
        }
    }
}
