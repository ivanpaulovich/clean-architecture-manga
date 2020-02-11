// <copyright file="SecurityService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using System.Threading.Tasks;
    using Customers.ValueObjects;
    using ValueObjects;

    /// <summary>
    ///     Security
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#domain-service">
    ///         Domain
    ///         Service Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public class SecurityService
    {
        private readonly IUserFactory userFactory;
        private readonly IUserRepository userRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityService" /> class.
        /// </summary>
        /// <param name="userFactory">User Factory.</param>
        /// <param name="userRepository">User Repository.</param>
        public SecurityService(
            IUserFactory userFactory,
            IUserRepository userRepository)
        {
            this.userFactory = userFactory;
            this.userRepository = userRepository;
        }

        /// <summary>
        ///     Create User Credentials.
        /// </summary>
        /// <param name="customerId">CustomerId.</param>
        /// <param name="externalUserId">External User Id.</param>
        /// <returns>The User.</returns>
        public async Task<IUser> CreateUserCredentials(CustomerId customerId, ExternalUserId externalUserId)
        {
            var user = this.userFactory.NewUser(customerId, externalUserId);
            await this.userRepository.Add(user)
                .ConfigureAwait(false);
            return user;
        }
    }
}
