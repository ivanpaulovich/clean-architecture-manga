// <copyright file="OnBoardCustomerInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OnBoardCustomer
{
    using Domain.Customers.ValueObjects;
    using Services;

    /// <summary>
    ///     On-board Customer Input Message.
    /// </summary>
    public sealed class OnBoardCustomerInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OnBoardCustomerInput" /> class.
        /// </summary>
        public OnBoardCustomerInput(string firstName, string lastName, string ssn)
        {
            this.ModelState = new Notification();

            if (!string.IsNullOrWhiteSpace(ssn))
            {
                this.SSN = new SSN(ssn);
            }
            else
            {
                this.ModelState.Add("SSN", "SSN is required.");
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                this.FirstName = new Name(firstName);
            }
            else
            {
                this.ModelState.Add("FirstName", "First name is required.");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                this.LastName = new Name(lastName);
            }
            else
            {
                this.ModelState.Add("LastName", "Last name is required.");
            }
        }

        internal Notification ModelState { get; }
        internal Name FirstName { get; }
        internal Name LastName { get; }
        internal SSN SSN { get; }
    }
}
