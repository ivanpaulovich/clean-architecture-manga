namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class GetAccountDetailsInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new GetAccountDetailsInput(
                    new AccountId(Guid.Empty)));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new GetAccountDetailsInput(
                new AccountId(Guid.NewGuid()));
            Assert.NotNull(actual);
        }
    }
}
