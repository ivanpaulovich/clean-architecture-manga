using System;
using Swashbuckle.AspNetCore.Examples;

namespace Manga.WebApi.UseCases.V1.Withdraw
{
    public sealed class WithdrawRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new WithdrawRequest()
            {
                AccountId = new Guid("59be82bc-ebab-4d11-8acf-07f348a5572f"),
                Amount = 300.5M
            };

            return request;
        }
    }
}