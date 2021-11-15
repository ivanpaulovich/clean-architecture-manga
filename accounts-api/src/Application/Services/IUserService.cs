// <copyright file="IUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Services;

/// <summary>
///     User Service.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Gets the Current User Id.
    /// </summary>
    /// <returns>User.</returns>
    string GetCurrentUserId();
}
