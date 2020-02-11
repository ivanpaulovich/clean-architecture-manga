// <copyright file="ICustomerRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using System.Threading.Tasks;
    using ValueObjects;

    /// <summary>
    ///     Customer
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#repository">
    ///         Repository
    ///         Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        ///     Gets the Customer by Id.
        /// </summary>
        /// <param name="customerId">CustomerId.</param>
        /// <returns>Customer.</returns>
        Task<ICustomer> GetBy(CustomerId customerId);

        /// <summary>
        ///     Adds the Customer.
        /// </summary>
        /// <param name="customer">Customer object.</param>
        /// <returns>Task.</returns>
        Task Add(ICustomer customer);

        /// <summary>
        ///     Updates the Customer.
        /// </summary>
        /// <param name="customer">Customer object.</param>
        /// <returns>Task.</returns>
        Task Update(ICustomer customer);
    }
}
