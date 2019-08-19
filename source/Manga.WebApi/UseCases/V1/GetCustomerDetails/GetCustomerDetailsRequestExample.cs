namespace Manga.WebApi.UseCases.V1.GetCustomerDetails
{
    using System;
    using Swashbuckle.AspNetCore.Examples;

    public sealed class GetCustomerDetailsRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new GetCustomerDetailsRequest()
            {   
                CustomerId = new Guid("de136a73-4253-4a05-84b8-43f902e2f5cb")
            };

            return request;
        }
    }
}