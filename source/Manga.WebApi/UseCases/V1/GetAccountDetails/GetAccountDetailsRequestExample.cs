namespace Manga.WebApi.UseCases.V1.GetAccountDetails
{
    using System;
    using Swashbuckle.AspNetCore.Examples;
    
    public sealed class GetAccountDetailsRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new GetAccountDetailsRequest()
            {
                AccountId = new Guid("0a62a8f8-3088-4581-8c07-643d7832e73d")
            };

            return request;
        }
    }
}