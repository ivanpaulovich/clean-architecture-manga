// <copyright file="IOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccounts
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Listed accounts.
        /// </summary>
        void Ok(IList<Account> accounts);
    }
}
