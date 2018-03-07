namespace Manga.UseCaseTests
{
    using Xunit;
    using NSubstitute;
    using Manga.Application;
    using Manga.Infrastructure.Mappings;
    using System;
    using Manga.Application.Repositories;

    public class CustomerTests
    {
        public IAccountReadOnlyRepository accountReadOnlyRepository;
        public IAccountWriteOnlyRepository accountWriteOnlyRepository;
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public IOutputConverter converter;

        public CustomerTests()
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
            Assert.True(output.Output.Customer.CustomerId != Guid.Empty);
            Assert.True(output.Output.Account.AccountId != Guid.Empty);
        }
    }
}
