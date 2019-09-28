namespace Manga.UnitTests.InputValidationTests
{
    using System;
    using Manga.Application.Boundaries.Transfer;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public sealed class TransferInputValidationTests
    {
        [Fact]
        public void GivenEmptyOriginAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new TransferInput(
                    Guid.Empty,
                    Guid.NewGuid(),
                    new PositiveMoney(10)
                ));
            Assert.Contains("originAccountId", actualEx.Message);
        }

        [Fact]
        public void GivenEmptyDestinationAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new TransferInput(
                    Guid.NewGuid(),
                    Guid.Empty,
                    new PositiveMoney(10)
                ));
            Assert.Contains("destinationAccountId", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new TransferInput(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}