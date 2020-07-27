// <copyright file="ICloseAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Close Account
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface ICloseAccountUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        Task Execute(CloseAccountInput input);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
