// <copyright file="IGetCustomerUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetCustomer
{
    using System.Threading.Tasks;

    /// <summary>
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IGetCustomerUseCase
    {
        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <returns></returns>
        Task Execute();

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
