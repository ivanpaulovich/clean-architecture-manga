namespace ComponentTests.V1
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

        private async Task GetCustomer()
        {
            HttpClient client = this._factory.CreateClient();
            await client.GetStringAsync("/api/v1/Customers/")
                .ConfigureAwait(false);
        }

        private async Task GetAccount(string accountId)
        {
            HttpClient client = this._factory.CreateClient();
            await client.GetStringAsync($"/api/v1/Accounts/{accountId}")
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

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Contains("customerId", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string customerId = customer["customer"]["customerId"].Value<string>();
            string accountId = ((JContainer)customer["accounts"]).First["accountId"].Value<string>();

            return new Tuple<string, string>(customerId, accountId);
        }

        private async Task Deposit(string account, decimal amount)
        {
            HttpClient client = this._factory.CreateClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("accountId", account),
                new KeyValuePair<string, string>("amount", amount.ToString(CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("currency", string.Empty)
            });

            HttpResponseMessage response = await client.PatchAsync("api/v1/Accounts/Deposit", content)
                .ConfigureAwait(false);
            var result = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task Withdraw(string account, decimal amount)
        {
            HttpClient client = this._factory.CreateClient();

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("accountId", account),
                new KeyValuePair<string, string>("amount", amount.ToString(CultureInfo.InvariantCulture))
            });

            HttpResponseMessage response = await client.PatchAsync("api/v1/Accounts/Withdraw", content)
                .ConfigureAwait(false);
            var responseBody = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task Close(string account)
        {
            HttpClient client = this._factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync($"api/v1/Accounts/{account}")
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Register_Deposit_Withdraw_Close()
        {
            (_, string item2) = await this.Register(500)
                .ConfigureAwait(false);
            await this.GetCustomer()
                .ConfigureAwait(false);
            await this.GetAccount(item2)
                .ConfigureAwait(false);
            await this.Withdraw(item2, 300)
                .ConfigureAwait(false);
            await this.GetCustomer()
                .ConfigureAwait(false);
            await this.Deposit(item2, 500)
                .ConfigureAwait(false);
            await this.Deposit(item2, 300)
                .ConfigureAwait(false);
            await this.GetCustomer()
                .ConfigureAwait(false);
            await this.Withdraw(item2, 500)
                .ConfigureAwait(false);
            await this.Withdraw(item2, 500)
                .ConfigureAwait(false);
            await this.Close(item2)
                .ConfigureAwait(false);
        }
    }
}
