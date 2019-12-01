namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.Deposit;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class DepositInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new DepositInput(
                    new AccountId(Guid.Empty),
                    new PositiveMoney(10)));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new DepositInput(
                new AccountId(Guid.NewGuid()),
                new PositiveMoney(10));
            Assert.NotNull(actual);
        }
    }
}
