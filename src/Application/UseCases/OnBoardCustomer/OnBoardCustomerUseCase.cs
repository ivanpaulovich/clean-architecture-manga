// <copyright file="OnBoardCustomerUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OnBoardCustomer
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class OnBoardCustomerUseCase : IOnBoardCustomerUseCase
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="customerRepository"></param>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        /// <param name="customerFactory"></param>
        public OnBoardCustomerUseCase(
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository,
            IUserService userService,
            IUserRepository userRepository,
            ICustomerFactory customerFactory)
        {
            this._unitOfWork = unitOfWork;
            this._customerRepository = customerRepository;
            this._userService = userService;
            this._userRepository = userRepository;
            this._customerFactory = customerFactory;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public async Task Execute(OnBoardCustomerInput input)
        {
            IUser existingUser = await this.GetExistingUser()
                .ConfigureAwait(false);

            if (existingUser is UserNull)
            {
                input.ModelState.Add(nameof(existingUser.UserId), "User does not exist.");
            }

            if (await this.IsDuplicatedCustomer(existingUser.UserId)
                .ConfigureAwait(false))
            {
                input.ModelState.Add(nameof(existingUser.UserId), "Customer already on-boarded.");
            }

            if (input.ModelState.IsValid)
            {
                await this.OnBoardCustomerInternal(input.FirstName, input.LastName, input.SSN, existingUser.UserId)
                    .ConfigureAwait(false);
            }

            this._outputPort?.Invalid(input.ModelState);
        }

        private async Task OnBoardCustomerInternal(Name firstName, Name lastName, SSN ssn, UserId userId)
        {
            Customer customer = this._customerFactory
                .NewCustomer(ssn, firstName, lastName, userId);

            await this.OnBoardCustomer(customer)
                .ConfigureAwait(false);

            this._outputPort?.Ok(customer);
        }

        private async Task OnBoardCustomer(Customer customer)
        {
            await this._customerRepository
                .Add(customer)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }

        private async Task<IUser> GetExistingUser()
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            IUser existingUser = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            return existingUser;
        }

        private async Task<bool> IsDuplicatedCustomer(UserId userId)
        {
            ICustomer existingCustomer = await this._customerRepository
                .Find(userId)
                .ConfigureAwait(false);

            return existingCustomer is Customer;
        }
    }
}
