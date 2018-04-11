namespace Manga.UseCaseTests
{
    using Xunit;
    using Manga.Domain.Customers;
    using NSubstitute;
    using Manga.Application;
    using Manga.Infrastructure.Mappings;
    using System;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Accounts;
    using Manga.Application.Repositories;

    public class AccountTests
    {
        public IAccountReadOnlyRepository accountReadOnlyRepository;
        public IAccountWriteOnlyRepository accountWriteOnlyRepository;
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public IOutputConverter converter;

        public AccountTests()
        {
            accountReadOnlyRepository = Substitute.For<IAccountReadOnlyRepository>();
            accountWriteOnlyRepository = Substitute.For<IAccountWriteOnlyRepository>();
            customerReadOnlyRepository = Substitute.For<ICustomerReadOnlyRepository>();
            customerWriteOnlyRepository = Substitute.For<ICustomerWriteOnlyRepository>();

            converter = new OutputConverter();
        }

        [Theory]
        [InlineData("08724050601", "Ivan Paulovich", 300)]
        [InlineData("08724050601", "Ivan Paulovich Pinheiro Gomes", 100)]
        [InlineData("444", "Ivan Paulovich", 500)]
        [InlineData("08724050", "Ivan Paulovich", 300)]
        public async void Register_Valid_User_Account(string personnummer, string name, double amount)
        {
            var output = Substitute.For<CustomPresenter<Application.UseCases.Register.RegisterOutput>>();

            var registerUseCase = new Application.UseCases.Register.RegisterInteractor(
                customerWriteOnlyRepository,
                accountWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Register.RegisterInput(
                personnummer,
                name,
                amount
            );

            await registerUseCase.Process(request);

            Assert.Equal(request.PIN, output.Output.Customer.Personnummer);
            Assert.Equal(request.Name, output.Output.Customer.Name);
            Assert.True(Guid.Empty != output.Output.Customer.CustomerId);
            Assert.True(Guid.Empty != output.Output.Account.AccountId);
        }


        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Deposit_Valid_Amount(string accountId, double amount)
        {
            var account = new Account(Guid.NewGuid());
            var customer = Substitute.For<Customer>();

            accountReadOnlyRepository
                .Get(Guid.Parse(accountId))
                .Returns(account);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Deposit.DepositOutput>>();

            var depositUseCase = new Application.UseCases.Deposit.DepositInteractor(
                accountReadOnlyRepository,
                accountWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Deposit.DepositInput(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Process(request);

            Assert.Equal(request.Amount, output.Output.Transaction.Amount);
        }

        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Withdraw_Valid_Amount(string accountId, double amount)
        {
            Account account = new Account(Guid.NewGuid());
            account.Deposit(new Credit(account.Id, 1000));

            accountReadOnlyRepository
                .Get(Guid.Parse(accountId))
                .Returns(account);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Withdraw.WithdrawOutput>>();

            var depositUseCase = new Application.UseCases.Withdraw.WithdrawInteractor(
                accountReadOnlyRepository,
                accountWriteOnlyRepository,
                output,
                converter
            );

            var request = new Application.UseCases.Withdraw.WithdrawInput(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Process(request);

            Assert.Equal(request.Amount, output.Output.Transaction.Amount);
        }

        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Close(double amount)
        {
            var account = new Account(Guid.NewGuid());
            account.Deposit(new Credit(account.Id, amount));

            Assert.Throws<AccountCannotBeClosedException>(
                () => account.Close());
        }
    }
}
