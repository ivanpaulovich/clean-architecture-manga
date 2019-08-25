namespace Manga.UnitTests.InputValidationTests
{
    using System;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public sealed class WithdrawInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new WithdrawInput(
                    Guid.Empty,
                    new PositiveAmount(10)
                ));
            Assert.Contains("accountId", actualEx.Message);        
        }

        [Fact]
        public void GivenNullAmount_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new WithdrawInput(
                    Guid.NewGuid(),
                    null
                ));
            Assert.Contains("amount", actualEx.Message);        
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new WithdrawInput(
                    Guid.NewGuid(),
                    new PositiveAmount(10)
                );
            Assert.NotNull(actual);
        }
    }
}