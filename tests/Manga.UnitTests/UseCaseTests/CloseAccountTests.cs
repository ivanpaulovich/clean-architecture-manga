namespace Manga.UnitTests.UseCasesTests
{
    using Xunit;
    using System;
    using Manga.Domain.Accounts;

    public sealed class CloseAccountTests
    {
        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Closing(double amount)
        {
            var account = new Account(Guid.NewGuid());
            account.Deposit(amount);
            account.CanBeClosed();
        }
    }
}
