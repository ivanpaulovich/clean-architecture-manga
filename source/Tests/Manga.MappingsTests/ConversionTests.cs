namespace Manga.MappingsTests
{
    using Manga.Application;
    using Manga.Application.Responses;
    using Manga.Domain.Customers.Accounts;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.Mappings;
    using Xunit;

    public class ConversionTests
    {
        public IResponseConverter converter;

        public ConversionTests()
        {
            converter = new ResponseConverter();
        }

        [Fact]
        public void Convert_Debit_Valid_TransactionResponse()
        {
            Debit debit = new Debit(new Amount(100));

            var result = converter.Map<TransactionResponse>(debit);
            Assert.Equal(debit.Amount.Value, result.Amount);
            Assert.Equal(debit.TransactionDate, result.TransactionDate);
            Assert.Equal(debit.Description, result.Description);
        }
    }
}
