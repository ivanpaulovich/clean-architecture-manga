namespace UnitTests.InputValidationTests
{
    using Application.Boundaries.Register;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Xunit;

    public sealed class RegisterInputValidationTests
    {
        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new RegisterInput(
                new SSN("19860817999"),
                new PositiveMoney(10));
            Assert.NotNull(actual);
        }
    }
}
