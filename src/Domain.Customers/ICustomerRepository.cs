// <copyright file="ICustomerRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using System.Threading.Tasks;
    using Common;

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
        ///     Finds the Customer by External User Id.
        /// </summary>
        /// <param name="userId">UserId.</param>
        /// <returns>Customer.</returns>
        Task<ICustomer> Find(UserId userId);

        /// <summary>
        ///     Adds the Customer.
        /// </summary>
        /// <param name="customer">Customer object.</param>
        /// <returns>Task.</returns>
        Task Add(Customer customer);

        /// <summary>
        ///     Updates the Customer.
        /// </summary>
        /// <param name="customer">Customer object.</param>
        /// <returns>Task.</returns>
        Task Update(Customer customer);
    }
}
