namespace Acerola.Domain.UnitTests
{
    using System;
    using Xunit;
    using Acerola.Domain.Accounts;
    using Acerola.Domain.Customers;
    using Acerola.Application.UseCases;
    using NSubstitute;
    using Acerola.Domain.ValueObjects;

    public class ApplicationTests
    {
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public IAccountReadOnlyRepository accountReadOnlyRepository;
        public IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public ApplicationTests()
        {
            customerReadOnlyRepository = Substitute.For<ICustomerReadOnlyRepository>();
            customerWriteOnlyRepository = Substitute.For<ICustomerWriteOnlyRepository>();
            accountReadOnlyRepository = Substitute.For<IAccountReadOnlyRepository>();
            accountWriteOnlyRepository = Substitute.For<IAccountWriteOnlyRepository>();
        }

        [Fact]
        public async void Register_Valid_User_Account()
        {
            Register command = new Register()
            {
                PIN = "08724050601",
                InitialAmount = 300,
                Name = "Ivan Paulovich"
            };

            Register sut = new Register(
                customerWriteOnlyRepository,
                accountWriteOnlyRepository);

            Customer registered = await sut.Handle(command);

            Assert.Equal(command.PIN, registered.PIN.Text);
            Assert.Equal(command.Name, registered.Name.Text);
            Assert.True(registered.Id != Guid.Empty);
        }

        [Fact]
        public async void Deposit_Valid_Amount()
        {
            Deposit command = new Deposit()
            {
                AccountId = Guid.NewGuid(),
                Amount = 600
            };

            accountReadOnlyRepository
                .Get(command.AccountId)
                .Returns(new Account());

            Deposit sut = new Deposit(
                accountReadOnlyRepository,
                accountWriteOnlyRepository);

            Credit credit = await sut.Handle(command);

            Assert.Equal(command.Amount, credit.Amount.Value);
            Assert.Equal("Credit", credit.Description);
            Assert.True(credit.Id != Guid.Empty);
        }

        [Fact]
        public async void Withdraw_Valid_Amount()
        {
            Withdraw command = new Withdraw()
            {
                AccountId = Guid.NewGuid(),
                Amount = 600
            };

            Account account = Substitute.For<Account>();
            account.Deposit(Credit.Create(Amount.Create(1000)));

            accountReadOnlyRepository
                .Get(command.AccountId)
                .Returns(account);

            Withdraw sut = new Withdraw(
                accountReadOnlyRepository,
                accountWriteOnlyRepository);

            Debit debit = await sut.Handle(command);

            Assert.Equal(command.Amount, debit.Amount.Value);
            Assert.Equal("Debit", debit.Description);
            Assert.True(debit.Id != Guid.Empty);
        }
    }
}
