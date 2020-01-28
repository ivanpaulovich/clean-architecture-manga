namespace Application.Boundaries.Register
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    /// <summary>
    /// Register Input Message.
    /// </summary>
    public sealed class RegisterInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterInput"/> class.
        /// </summary>
        /// <param name="ssn">SSN.</param>
        /// <param name="initialAmount">Positive amount.</param>
        public RegisterInput(
            SSN ssn,
            PositiveMoney initialAmount)
        {
            this.SSN = ssn;
            this.InitialAmount = initialAmount;
        }

        /// <summary>
        /// Gets the SSN.
        /// </summary>
        public SSN SSN { get; }

        /// <summary>
        /// Gets the Initial Amount.
        /// </summary>
        public PositiveMoney InitialAmount { get; }
    }
}
