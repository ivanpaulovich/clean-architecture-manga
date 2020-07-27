// <copyright file="IGetAccountOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount
{
    using Domain.Accounts;
    using Services;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid(Notification notification);

        /// <summary>
        ///     Account closed.
        /// </summary>
        void Ok(Account account);

        /// <summary>
        ///     Account closed.
        /// </summary>
        void NotFound();
    }
}
