namespace ComponentTests.V2
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using WebApi;
    using Xunit;

    public sealed class SunnyDayTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public SunnyDayTests(CustomWebApplicationFactory factory)
        {
            this._factory = factory;
        }

        [Fact]
        public async Task Register_Deposit_Withdraw_Close()
        {
            Tuple<string, string> customerIdAccountId = await this.Register(100)
                .ConfigureAwait(false);
            await this.GetAccount(customerIdAccountId.Item2)
                .ConfigureAwait(false);
        }

        private async Task GetAccount(string accountId)
        {
            var client = this._factory.CreateClient();
            string result = await client.GetStringAsync($"/api/v2/Accounts/{accountId}")
                .ConfigureAwait(false);
        }

        private async Task<Tuple<string, string>> Register(decimal initialAmount)
        {
            var client = this._factory.CreateClient();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ssn", "8608179999"),
                new KeyValuePair<string, string>("initialAmount", initialAmount.ToString()),
            });

            var response = await client.PostAsync("api/v1/Customers", content)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Contains("customerId", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string customerId = customer["customerId"].Value<string>();
            string accountId = ((JContainer)customer["accounts"]).First["accountId"].Value<string>();

            return new Tuple<string, string>(customerId, accountId);
        }
    }
}
