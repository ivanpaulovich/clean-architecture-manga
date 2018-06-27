namespace Manga.Domain.Tests
{
    using Xunit;
    using Manga.Domain.Accounts;
    using System;
    using System.Collections.Generic;

    public class TransactionCollectionTests
    {
        [Fact]
        public void Multiple_Transactions_Should_Be_Added()
        {
            TransactionCollection transactionCollection = new TransactionCollection();
            transactionCollection.Add(new List<ITransaction>()
            {
                new Credit(Guid.Empty, 100),
                new Debit(Guid.Empty, 30)
            });

            Assert.Equal(2, transactionCollection.GetTransactions().Count);
        }
    }
}
