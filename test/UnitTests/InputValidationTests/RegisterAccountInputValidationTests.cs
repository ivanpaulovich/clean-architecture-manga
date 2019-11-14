namespace UnitTests.InputValidationTests
{
    using Application.Boundaries.RegisterAccount;
    using Application.Exceptions;
    using Domain.ValueObjects;
    using Xunit;

    public sealed class RegisterAccountInputValidationTests
    {
        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new RegisterAccountInput(
                new SSN("19860817999"),
                new Name("Ivan"),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}
