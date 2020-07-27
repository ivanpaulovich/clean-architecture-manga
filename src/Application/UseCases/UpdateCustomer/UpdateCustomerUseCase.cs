// <copyright file="UpdateCustomerUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.UpdateCustomer
{
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
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
        public UpdateCustomerUseCase(
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository,
            IUserService userService,
            IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._customerRepository = customerRepository;
            this._userService = userService;
            this._userRepository = userRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(UpdateCustomerInput input)
        {
            if (input.ModelState.IsValid)
            {
                return this.UpdateCustomerInternal(input.FirstName, input.LastName, input.SSN);
            }

            this._outputPort?.Invalid(input.ModelState);
            return Task.CompletedTask;
        }

        private async Task UpdateCustomerInternal(Name firstName, Name lastName, SSN ssn)
        {
            ICustomer existingCustomer = await this.GetExistingCustomer()
                .ConfigureAwait(false);

            if (existingCustomer is Customer updateCustomer)
            {
                updateCustomer.Update(ssn, firstName, lastName);

                await this.UpdateCustomer(updateCustomer)
                    .ConfigureAwait(false);

                this._outputPort?.Ok(updateCustomer);
                return;
            }

            this._outputPort?.NotFound();
        }

        private async Task UpdateCustomer(Customer existingCustomer)
        {
            await this._customerRepository
                .Update(existingCustomer)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }

        private async Task<ICustomer> GetExistingCustomer()
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            IUser existingUser = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            ICustomer existingCustomer = await this._customerRepository
                .Find(existingUser.UserId)
                .ConfigureAwait(false);

            return existingCustomer;
        }
    }
}
