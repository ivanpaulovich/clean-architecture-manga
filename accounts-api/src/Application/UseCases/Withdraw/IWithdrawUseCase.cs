// <copyright file="IWithdrawUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    ///     Withdraw
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IWithdrawUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <param name="accountId">AccountId.</param>
        /// <param name="amount">Positive amount to withdraw.</param>
        /// <param name="currency">Currency from amount.</param>
        Task Execute(Guid accountId, decimal amount, string currency);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
