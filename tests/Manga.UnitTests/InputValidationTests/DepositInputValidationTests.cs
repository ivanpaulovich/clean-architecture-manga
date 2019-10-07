namespace Manga.UnitTests.InputValidationTests
{
    using System;
    using Manga.Application.Boundaries.Deposit;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public sealed class DepositInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new DepositInput(
                    Guid.Empty,
                    new PositiveMoney(10)
                ));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new DepositInput(
                Guid.NewGuid(),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}
