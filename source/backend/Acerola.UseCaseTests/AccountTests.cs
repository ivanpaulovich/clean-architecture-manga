namespace Acerola.UseCaseTests
{
    using Xunit;
    using Acerola.Domain.Accounts;
    using Acerola.Domain.Customers;
    using NSubstitute;
    using Acerola.Application;
    using Acerola.Infrastructure.Mappings;
    using System;
    using Acerola.Domain.ValueObjects;

    public class AccountTests
    {
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public IAccountReadOnlyRepository accountReadOnlyRepository;
        public IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public IResponseConverter converter;

        public AccountTests()
        {
            customerReadOnlyRepository = Substitute.For<ICustomerReadOnlyRepository>();
            customerWriteOnlyRepository = Substitute.For<ICustomerWriteOnlyRepository>();
            accountReadOnlyRepository = Substitute.For<IAccountReadOnlyRepository>();
            accountWriteOnlyRepository = Substitute.For<IAccountWriteOnlyRepository>();        
            converter = new ResponseConverter();
        }

        [Theory]
        [InlineData("08724050601", "Ivan Paulovich", 300)]
        [InlineData("08724050601", "Ivan Paulovich Pinheiro Gomes", 100)]
        [InlineData("444", "Ivan Paulovich", 500)]
        [InlineData("08724050", "Ivan Paulovich", 300)]
        public async void Register_Valid_User_Account(string personnummer, string name, double amount)
        {
            var output = Substitute.For<CustomPresenter<Application.UseCases.Register.Response>>();

            var registerUseCase = new Application.UseCases.Register.Interactor(
                customerWriteOnlyRepository,
                accountWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Register.Request(
                personnummer,
                name,
                amount
            );

            await registerUseCase.Handle(request);

            Assert.Equal(request.PIN, output.Response.Customer.Personnummer);
            Assert.Equal(request.Name, output.Response.Customer.Name);
            Assert.True(Guid.Empty != output.Response.Customer.CustomerId);
            Assert.True(Guid.Empty != output.Response.Account.AccountId);
        }


        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Deposit_Valid_Amount(string accountId, double amount)
        {
            accountReadOnlyRepository
                .Get(Guid.Parse(accountId))
                .Returns(new Account());

            var output = Substitute.For<CustomPresenter<Application.UseCases.Deposit.Response>>();

            var depositUseCase = new Application.UseCases.Deposit.Interactor(
                accountReadOnlyRepository,
                accountWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Deposit.Request(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Handle(request);

            Assert.Equal(request.Amount, output.Response.Transaction.Amount);
        }

        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Withdraw_Valid_Amount(string accountId, double amount)
        {
            Account account = Substitute.For<Account>();
            account.Deposit(new Credit(new Amount(1000)));

            accountReadOnlyRepository
                .Get(Guid.Parse(accountId))
                .Returns(account);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Withdraw.Response>>();

            var depositUseCase = new Application.UseCases.Withdraw.Interactor(
                accountReadOnlyRepository,
                accountWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Withdraw.Request(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Handle(request);

            Assert.Equal(request.Amount, output.Response.Transaction.Amount);
        }
    }
}
