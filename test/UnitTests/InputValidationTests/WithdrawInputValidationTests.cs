namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.Withdraw;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class WithdrawInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            EmptyAccountIdException actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new WithdrawInput(Guid.Empty, 10));
            Assert.Contains("accountId", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            WithdrawInput actual = new WithdrawInput(Guid.NewGuid(), 10);
            Assert.NotNull(actual);
        }
    }
}
