// <copyright file="SecurityService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using System;
    using System.Threading.Tasks;
    using Customers.ValueObjects;

    /// <summary>
    ///     Security
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#domain-service">
    ///         Domain
    ///         Service Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class SecurityService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityService" /> class.
        /// </summary>
        /// <param name="userRepository">User Repository.</param>
        public SecurityService(IUserRepository userRepository) => this._userRepository = userRepository;

        /// <summary>
        ///     Create User Credentials.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="customerId">Customer.</param>
        /// <returns>The User.</returns>
        public async Task<IUser> CreateUserCredentials(IUser user, CustomerId customerId)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Assign(customerId);
            await this._userRepository.Add(user)
                .ConfigureAwait(false);
            return user;
        }
    }
}
