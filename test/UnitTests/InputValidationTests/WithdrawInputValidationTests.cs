namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.Withdraw;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class WithdrawInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new WithdrawInput(
                    new AccountId(Guid.Empty),
                    new PositiveMoney(10)));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new WithdrawInput(
                new AccountId(Guid.NewGuid()),
                new PositiveMoney(10));
            Assert.NotNull(actual);
        }
    }
}
