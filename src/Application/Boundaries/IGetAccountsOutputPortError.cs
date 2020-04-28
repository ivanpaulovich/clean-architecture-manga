// <copyright file="IGetAccountsOutputPortError.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries
{
    /// <summary>
    ///     Error Output Port.
    /// </summary>
    public interface IGetAccountsOutputPortError
    {
        /// <summary>
        ///     Informs an error happened.
        /// </summary>
        /// <param name="message">Text description.</param>
        void WriteError(string message);
    }
}
