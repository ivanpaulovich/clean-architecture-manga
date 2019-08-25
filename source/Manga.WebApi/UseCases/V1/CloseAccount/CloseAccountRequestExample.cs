namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using System;
    using Swashbuckle.AspNetCore.Examples;

    public sealed class CloseAccountRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new CloseAccountRequest()
            {
                AccountId = new Guid("bfcd98e1-a0bf-48c5-9112-885509b1018b")
            };

            return request;
        }
    }
}