namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.Transfer;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class TransferInputValidationTests
    {
        [Fact]
        public void GivenEmptyOriginAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new TransferInput(
                    new AccountId(Guid.Empty),
                    new AccountId(Guid.NewGuid()),
                    new PositiveMoney(10)));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenEmptyDestinationAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new TransferInput(
                    new AccountId(Guid.NewGuid()),
                    new AccountId(Guid.Empty),
                    new PositiveMoney(10)));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new TransferInput(
                new AccountId(Guid.NewGuid()),
                new AccountId(Guid.NewGuid()),
                new PositiveMoney(10));
            Assert.NotNull(actual);
        }
    }
}
