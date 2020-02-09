// <copyright file="DepositPresenter.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Deposit;

    /// <summary>
    /// Deposit Presenter.
    /// </summary>
    public sealed class DepositPresenter : IOutputPort
    {
        /// <summary>
        /// 
        /// </summary>
        public DepositPresenter()
        {
            Deposits = new Collection<DepositOutput>();
            NotFounds = new Collection<string>();
        }

        public Collection<DepositOutput> Deposits { get; }

        public Collection<string> NotFounds { get; }

        public void Standard(DepositOutput output)
        {
            Deposits.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}
