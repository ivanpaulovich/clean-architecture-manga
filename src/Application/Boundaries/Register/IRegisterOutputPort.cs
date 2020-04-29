// <copyright file="IRegisterOutputPort.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IRegisterOutputPort
        : IOutputPortStandard<RegisterOutput>, IOutputPortError
    {
        /// <summary>
        ///     Informs the user is already registered.
        /// </summary>
        /// <param name="output">Details.</param>
        void HandleAlreadyRegisteredCustomer(RegisterOutput output);
    }
}
