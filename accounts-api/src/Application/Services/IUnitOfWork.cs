// <copyright file="IUnitOfWork.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Services;

using System.Threading.Tasks;

/// <summary>
///     Unit Of Work. Should only be used by Use Cases.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Applies all database changes.
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    Task<int> Save();
}
