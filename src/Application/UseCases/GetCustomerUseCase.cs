// <copyright file="GetCustomerUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.GetCustomer;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.Services;

    /// <summary>
    ///     Get Customer Details
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class GetCustomerUseCase : IGetCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IGetCustomerOutputPort _getCustomerOutputPort;
        private readonly IUserService _userService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetCustomerUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="getCustomerOutputPort">Output Port.</param>
        /// <param name="customerRepository">Customer Repository.</param>
        public GetCustomerUseCase(
            IUserService userService,
            IGetCustomerOutputPort getCustomerOutputPort,
            ICustomerRepository customerRepository)
        {
            this._userService = userService;
            this._getCustomerOutputPort = getCustomerOutputPort;
            this._customerRepository = customerRepository;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetCustomerInput input)
        {
            if (input is null)
            {
                this._getCustomerOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IUser user = this._userService.GetUser();

            ICustomer customer;

            if (user.CustomerId is { } customerId)
            {
                customer = await this._customerRepository
                    .GetBy(customerId)
                    .ConfigureAwait(false);

                if (customer == null)
                {
                    this._getCustomerOutputPort
                        .NotFound(Messages.CustomerDoesNotExist);
                    return;
                }
            }
            else
            {
                this._getCustomerOutputPort
                    .NotFound(Messages.CustomerDoesNotExist);
                return;
            }

            this.BuildOutput(customer);
        }

        private void BuildOutput(ICustomer customer)
        {
            var output = new GetCustomerOutput(customer);
            this._getCustomerOutputPort
                .Standard(output);
        }
    }
}
