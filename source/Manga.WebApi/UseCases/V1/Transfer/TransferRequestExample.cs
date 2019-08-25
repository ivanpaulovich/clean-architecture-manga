using System;
using Swashbuckle.AspNetCore.Examples;

namespace Manga.WebApi.UseCases.V1.Transfer
{
    public sealed class TransferRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new TransferRequest()
            {
                Amount = 200.5,
                DestinationAccountId = new Guid("56d69e61-0da6-4ec1-be6c-7e4a5034cbb7"),
                OriginAccountId = new Guid("52badddb-c9ee-4dac-93db-8392417ff206")
            };

            return request;
        }
    }
}