// <copyright file="IGetAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Gets the Account
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IGetAccountUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Execute(GetAccountInput input);

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="outputPort"></param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
