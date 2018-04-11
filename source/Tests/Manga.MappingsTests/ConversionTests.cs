namespace Manga.MappingsTests
{
    using Manga.Application;
    using Manga.Application.Outputs;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.Mappings;
    using System;
    using Xunit;

    public class ConversionTests
    {
        public IOutputConverter converter;

        public ConversionTests()
        {
            converter = new OutputConverter();
        }

        [Fact]
        public void Convert_Debit_Valid_TransactionResponse()
        {
            Debit debit = new Debit(Guid.NewGuid(), 100);

            var result = converter.Map<TransactionOutput>(debit);
            Assert.Equal(debit.Amount.Value, result.Amount);
            Assert.Equal(debit.TransactionDate, result.TransactionDate);
            Assert.Equal(debit.Description, result.Description);
        }
    }
}
