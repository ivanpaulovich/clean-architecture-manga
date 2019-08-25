namespace Manga.UnitTests.InputValidationTests
{
    using System;
    using Manga.Application.Boundaries.CloseAccount;
    using Manga.Application.Exceptions;
    using Xunit;

    public sealed class CloseAccountInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new CloseAccountInput(
                    Guid.Empty
                ));
            Assert.Contains("accountId", actualEx.Message);        
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new CloseAccountInput(
                    Guid.NewGuid()
                );
            Assert.NotNull(actual);
        }
    }
}