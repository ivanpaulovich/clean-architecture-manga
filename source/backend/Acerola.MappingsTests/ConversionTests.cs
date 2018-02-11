using Acerola.Application;
using Acerola.Application.Responses;
using Acerola.Domain.Accounts;
using Acerola.Domain.ValueObjects;
using Acerola.Infrastructure.Mappings;
using System;
using Xunit;

namespace Acerola.MappingsTests
{
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
