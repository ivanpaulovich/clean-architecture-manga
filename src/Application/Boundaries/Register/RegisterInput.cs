// <copyright file="RegisterInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    /// <summary>
    ///     Register Input Message.
    /// </summary>
    public sealed class RegisterInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterInput" /> class.
        /// </summary>
        /// <param name="ssn">SSN.</param>
        /// <param name="initialAmount">Positive amount.</param>
        public RegisterInput(
            string ssn,
            decimal initialAmount)
        {
            this.SSN = new SSN(ssn);
            this.InitialAmount = new PositiveMoney(initialAmount);
        }

        /// <summary>
        ///     Gets the SSN.
        /// </summary>
        public SSN SSN { get; }

        /// <summary>
        ///     Gets the Initial Amount.
        /// </summary>
        public PositiveMoney InitialAmount { get; }
    }
}
