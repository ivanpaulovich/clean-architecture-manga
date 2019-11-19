namespace UnitTests.ServicesTests
{
    using Domain.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Services;
    using Xunit;

    public sealed class HashingServiceTests
    {
        private readonly HashingService _hashingService;

        public HashingServiceTests()
        {
            _hashingService = new HashingService();
        }

        [Fact]
        public void GivenValidData_HashCreated()
        {
            string password = "password";

            Password hashedPassword = _hashingService.Hash(password);

            Assert.NotNull(hashedPassword.ToString());
        }

        [Fact]
        public void GivenValidData_HashCreated_ContainsPrefix()
        {
            Password hashedPassword = _hashingService.Hash("password");

            bool containsPrefix = hashedPassword.ToString().Contains("$MYHASH$V1");

            Assert.True(containsPrefix);
        }

        [Fact]
        public void GivenValidHash_IsValid()
        {
            const string password = "password";
            const string hashedPassword = "$MYHASH$V1$10000$pMan7P0kKkE18lE29oR4pntrg3/7VSpZiHLnj3gR7FONcYji";

            bool isValid = _hashingService.Verify(password, hashedPassword);

            Assert.True(isValid);
        }
    }
}
