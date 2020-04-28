// <copyright file="IUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security.Services
{
    /// <summary>
    ///     User Service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Gets the User.
        /// </summary>
        /// <returns>User.</returns>
        IUser GetUser();
    }
}
