// <copyright file="IOnBoardCustomerUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OnBoardCustomer
{
    using System.Threading.Tasks;

    /// <summary>
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IOnBoardCustomerUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        Task Execute(OnBoardCustomerInput input);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
