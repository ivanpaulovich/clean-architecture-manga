namespace Manga.UseCaseTests
{
    using Xunit;
    using Manga.Domain.Customers;
    using NSubstitute;
    using Manga.Application;
    using Manga.Infrastructure.Mappings;
    using System;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Customers.Accounts;
    using System.Collections.Generic;

    public class AccountTests
    {
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public IResponseConverter converter;

        public AccountTests()
        {
            customerReadOnlyRepository = Substitute.For<ICustomerReadOnlyRepository>();
            customerWriteOnlyRepository = Substitute.For<ICustomerWriteOnlyRepository>();  
            converter = new ResponseConverter();
        }

        [Theory]
        [InlineData("08724050601", "Ivan Paulovich", 300)]
        [InlineData("08724050601", "Ivan Paulovich Pinheiro Gomes", 100)]
        [InlineData("444", "Ivan Paulovich", 500)]
        [InlineData("08724050", "Ivan Paulovich", 300)]
        public async void Register_Valid_User_Account(string personnummer, string name, double amount)
        {
            var output = Substitute.For<CustomPresenter<Application.UseCases.Register.RegisterResponse>>();

            var registerUseCase = new Application.UseCases.Register.RegisterInteractor(
                customerWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Register.RegisterCommand(
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
        [InlineData("08724050601", "Ivan Paulovich", "c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Deposit_Valid_Amount(string pin, string name,string accountId, double amount)
        {
            var account = Substitute.For<Account>();
            var customer = Substitute.For<Customer>();
            customer.FindAccount(Arg.Any<Guid>())
                .Returns(account);

            customerReadOnlyRepository
                .GetByAccount(Guid.Parse(accountId))
                .Returns(customer);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Deposit.DepositResponse>>();

            var depositUseCase = new Application.UseCases.Deposit.DepositInteractor(
                customerReadOnlyRepository,
                customerWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Deposit.DepositCommand(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Handle(request);

            Assert.Equal(request.Amount, output.Response.Transaction.Amount);
        }

        private int IList<T>()
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Withdraw_Valid_Amount(string accountId, double amount)
        {
            Account account = Substitute.For<Account>();
            account.Deposit(new Credit(new Amount(1000)));

            var customer = Substitute.For<Customer>();
            customer.FindAccount(Arg.Any<Guid>())
                .Returns(account);

            customerReadOnlyRepository
                .GetByAccount(Guid.Parse(accountId))
                .Returns(customer);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Withdraw.WithdrawResponse>>();

            var depositUseCase = new Application.UseCases.Withdraw.WithdrawInteractor(
                customerReadOnlyRepository,
                customerWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Withdraw.WithdrawCommand(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Handle(request);

            Assert.Equal(request.Amount, output.Response.Transaction.Amount);
        }
    }
}
