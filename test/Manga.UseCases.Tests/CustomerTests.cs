namespace Manga.UseCaseTests
{
    using Xunit;
    using Manga.Application.UseCases.Register;
    using Manga.Application.Repositories;
    using Moq;

    public class CustomerTests
    {
        [Theory]
        [InlineData(300)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(3300)]
        public async void Register_Valid_User_Account(double amount)
        {
            string personnummer = "8608178888";
            string name = "Ivan Paulovich";

            var mockCustomerWriteOnlyRepository = new Mock<ICustomerWriteOnlyRepository>();
            var mockAccountWriteOnlyRepository = new Mock<IAccountWriteOnlyRepository>();

            var sut = new RegisterUseCase(
                mockCustomerWriteOnlyRepository.Object,
                mockAccountWriteOnlyRepository.Object
            );

            var output = await sut.Execute(
                personnummer,
                name,
                amount);

            Assert.Equal(amount, output.Account.CurrentBalance);
        }
    }
}
