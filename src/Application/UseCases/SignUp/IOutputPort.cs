// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.SignUp
{
    using Domain.Security;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     User.
        /// </summary>
        void UserAlreadyExists(User user);

        /// <summary>
        ///     User.
        /// </summary>
        void Ok(User user);
    }
}
