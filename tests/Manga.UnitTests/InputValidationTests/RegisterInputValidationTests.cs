namespace Manga.UnitTests.InputValidationTests
{
    using Manga.Application.Boundaries.Register;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public sealed class RegisterInputValidationTests
    {
        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new RegisterInput(
                new SSN("19860817999"),
                new Name("Ivan"),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}