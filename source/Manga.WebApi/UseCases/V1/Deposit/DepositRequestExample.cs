using System;
using Swashbuckle.AspNetCore.Examples;

namespace Manga.WebApi.UseCases.V1.Deposit
{
    public sealed class DepositRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new DepositRequest()
            {
                AccountId = new Guid("0af32a50-b7c3-4919-a7cc-c171c20a97d8"),
                Amount = 340.5
            };

            return request;
        }
    }
}