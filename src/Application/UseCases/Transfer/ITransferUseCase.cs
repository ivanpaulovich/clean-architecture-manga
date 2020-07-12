// <copyright file="ITransferUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Transfer
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Transfer
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface ITransferUseCase
    {
        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Execute(TransferInput input);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
