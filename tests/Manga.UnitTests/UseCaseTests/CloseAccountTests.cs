namespace Manga.UnitTests.UseCasesTests
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public sealed class CloseAccountTests
    {
        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Closing(double amount)
        {
            var account = new Account(Guid.NewGuid());
            account.Deposit(new PositiveAmount(amount));
            account.IsClosingAllowed();
        }
    }
}