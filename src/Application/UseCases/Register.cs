namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// Register <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class Register : IUseCase
    {
        private readonly IUserService _userService;
        private readonly CustomerService _customerService;
        private readonly AccountService _accountService;
        private readonly SecurityService _securityService;
        private readonly IOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="customerService">Customer Service.</param>
        /// <param name="accountService">Account Service.</param>
        /// <param name="securityService">Security Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="unitOfWork">Unit of Work.</param>
        public Register(
            IUserService userService,
            CustomerService customerService,
            AccountService accountService,
            SecurityService securityService,
            IOutputPort outputPort,
            IUnitOfWork unitOfWork)
        {
            this._userService = userService;
            this._customerService = customerService;
            this._accountService = accountService;
            this._securityService = securityService;
            this._outputPort = outputPort;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RegisterInput input)
        {
            if (this._userService.GetCustomerId() is CustomerId customerId)
            {
                if (await this._customerService.IsCustomerRegistered(customerId))
                {
                    this._outputPort.CustomerAlreadyRegistered($"Customer already exists.");
                    return;
                }
            }

            var customer = await this._customerService.CreateCustomer(input.SSN, this._userService.GetUserName());
            var account = await this._accountService.OpenCheckingAccount(customer.Id, input.InitialAmount);
            var user = await this._securityService.CreateUserCredentials(customer.Id, this._userService.GetExternalUserId());

            customer.Register(account.Id);

            await this._unitOfWork.Save();

            this.BuildOutput(this._userService.GetExternalUserId(), customer, account);
        }

        private void BuildOutput(
            ExternalUserId externalUserId,
            ICustomer customer,
            IAccount account)
        {
            var output = new RegisterOutput(
                externalUserId,
                customer,
                account);
            this._outputPort.Standard(output);
        }
    }
}
