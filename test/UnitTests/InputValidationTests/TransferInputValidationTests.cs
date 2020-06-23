namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.Transfer;
    using Domain.Accounts.ValueObjects;
    using Xunit;

    public sealed class TransferInputValidationTests
    {
        [Fact]
        public void GivenEmptyDestinationAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            EmptyAccountIdException actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new TransferInput(Guid.NewGuid(), Guid.Empty, 10));
            Assert.Contains("accountId", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenEmptyOriginAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            EmptyAccountIdException actualEx = Assert.Throws<EmptyAccountIdException>(
                () => new TransferInput(Guid.Empty, Guid.NewGuid(), 10));
            Assert.Contains("accountId", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            TransferInput actual = new TransferInput(Guid.NewGuid(), Guid.NewGuid(), 10);
            Assert.NotNull(actual);
        }
    }
}
