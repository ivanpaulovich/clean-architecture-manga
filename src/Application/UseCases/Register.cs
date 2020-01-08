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
    /// Register Use Case.
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
            _userService = userService;
            _customerService = customerService;
            _accountService = accountService;
            _securityService = securityService;
            _outputPort = outputPort;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RegisterInput input)
        {
            if (_userService.GetCustomerId() is CustomerId customerId)
            {
                if (await _customerService.IsCustomerRegistered(customerId))
                {
                    _outputPort.CustomerAlreadyRegistered($"Customer already exists.");
                    return;
                }
            }

            var customer = await _customerService.CreateCustomer(input.SSN, _userService.GetUserName());
            var account = await _accountService.OpenCheckingAccount(customer.Id, input.InitialAmount);
            var user = await _securityService.CreateUserCredentials(customer.Id, _userService.GetExternalUserId());

            customer.Register(account.Id);

            await _unitOfWork.Save();

            BuildOutput(_userService.GetExternalUserId(), customer, account);
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
            _outputPort.Standard(output);
        }
    }
}
