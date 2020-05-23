namespace ComponentTests.V2
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public sealed class SunnyDayTests : IClassFixture<CustomWebApplicationFactory>
    {
        public SunnyDayTests(CustomWebApplicationFactory factory) => this._factory = factory;

        private readonly CustomWebApplicationFactory _factory;

        private async Task GetAccount(string accountId)
        {
            HttpClient client = this._factory.CreateClient();
            await client.GetAsync($"/api/v2/Accounts/{accountId}")
                .ConfigureAwait(false);
        }

        private async Task<Tuple<string, string>> Register(decimal initialAmount)
        {
            HttpClient client = this._factory.CreateClient();

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ssn", "8608179999"), new KeyValuePair<string, string>("initialAmount",
                    initialAmount.ToString(CultureInfo.InvariantCulture))
            });

            HttpResponseMessage response = await client.PostAsync("api/v1/Customers", content)
                .ConfigureAwait(false);

            string responseString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            Assert.Contains("customerId", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string customerId = customer["customer"]["customerId"].Value<string>();
            string accountId = ((JContainer)customer["accounts"]).First["accountId"].Value<string>();

            return new Tuple<string, string>(customerId, accountId);
        }

        [Fact]
        public async Task Register_Deposit_Withdraw_Close()
        {
            Tuple<string, string> customerIdAccountId = await this.Register(100)
                .ConfigureAwait(false);
            await this.GetAccount(customerIdAccountId.Item2)
                .ConfigureAwait(false);
        }
    }
}
