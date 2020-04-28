namespace UnitTests.InputValidationTests
{
    using Application.Boundaries.Register;
    using Xunit;

    public sealed class RegisterInputValidationTests
    {
        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new RegisterInput(
                "19860817999",
                10);
            Assert.NotNull(actual);
        }
    }
}
