namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.CloseAccount;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class CloseAccountInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            EmptyAccountIdException actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new AccountId(Guid.Empty));
            Assert.Contains("accountId", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            CloseAccountInput actual = new CloseAccountInput(Guid.NewGuid());
            Assert.NotNull(actual);
        }
    }
}
