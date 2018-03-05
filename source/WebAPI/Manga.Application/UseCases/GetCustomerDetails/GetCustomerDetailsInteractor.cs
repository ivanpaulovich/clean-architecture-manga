namespace Manga.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
    using System.Collections.Generic;
    using Manga.Application.Outputs;
    using Manga.Domain.Accounts;

    public class GetCustomerDetailsInteractor : IInputBoundary<GetCustomerDetaisInput>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<CustomerOutput> outputBoundary;
        private readonly IOutputConverter responseConverter;

        public GetCustomerDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<CustomerOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(GetCustomerDetaisInput message)
        {
            //
            // TODO: The following queries could be simplified
            //

            Customer customer = await customerReadOnlyRepository.Get(message.CustomerId);

            List<AccountOutput> accounts = new List<AccountOutput>();

            foreach (var accountId in customer.Accounts.Items)
            {
                Account account = await accountReadOnlyRepository.Get(accountId);

                //
                // TODO: The "Accout closed state" is not propagating to the Customer Aggregate
                //

                if (account != null)
                {
                    AccountOutput accountOutput = responseConverter.Map<AccountOutput>(account);
                    accounts.Add(accountOutput);
                }
            }

            CustomerOutput response = responseConverter.Map<CustomerOutput>(customer);

            response = new CustomerOutput(
                customer.Id,
                customer.PIN.Text,
                customer.Name.Text,
                accounts);

            outputBoundary.Populate(response);
        }
    }
}