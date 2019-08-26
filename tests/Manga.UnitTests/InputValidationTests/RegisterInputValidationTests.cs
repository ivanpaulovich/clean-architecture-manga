namespace Manga.UnitTests.InputValidationTests
{
    using Manga.Application.Boundaries.Register;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public sealed class RegisterInputValidationTests
    {
        [Fact]
        public void GivenNullSSN_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new RegisterInput(
                    null,
                    new Name("Ivan"),
                    new PositiveAmount(10)
                ));
            Assert.Contains("ssn", actualEx.Message);
        }

        [Fact]
        public void GivenNullName_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new RegisterInput(
                    new SSN("19860817999"),
                    null,
                    new PositiveAmount(10)
                ));
            Assert.Contains("name", actualEx.Message);
        }

        [Fact]
        public void GivenNullPositiveAmount_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new RegisterInput(
                    new SSN("19860817999"),
                    new Name("Ivan"),
                    null
                ));
            Assert.Contains("initialAmount", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new RegisterInput(
                new SSN("19860817999"),
                new Name("Ivan"),
                new PositiveAmount(10)
            );
            Assert.NotNull(actual);
        }
    }
}