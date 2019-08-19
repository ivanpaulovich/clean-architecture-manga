namespace Manga.WebApi.UseCases.V2.GetAccountDetails
{
    using System;
    using Swashbuckle.AspNetCore.Examples;
    
    public sealed class GetAccountDetailsRequestExampleV2 : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new GetAccountDetailsRequestV2()
            {
                AccountId = new Guid("0a62a8f8-3088-4581-8c07-643d7832e73d")
            };

            return request;
        }
    }
}