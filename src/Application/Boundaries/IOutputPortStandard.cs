// <copyright file="IOutputPortStandard.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries
{
    /// <summary>
    ///     Standard Output Port.
    /// </summary>
    /// <typeparam name="TUseCaseOutput">Any IUseCaseOutput.</typeparam>
    public interface IOutputPortStandard<in TUseCaseOutput>
    {
        /// <summary>
        ///     Writes to the Standard Output.
        /// </summary>
        /// <param name="output">The Output Port Message.</param>
        void Standard(TUseCaseOutput output);
    }
}
