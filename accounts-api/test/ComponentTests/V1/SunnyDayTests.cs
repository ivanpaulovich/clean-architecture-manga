namespace ComponentTests.V1
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public sealed class SunnyDayTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        public SunnyDayTests(CustomWebApplicationFactory factory) => this._factory = factory;

        private async Task<Tuple<Guid, decimal>> GetAccounts()
        {
            HttpClient client = this._factory.CreateClient();
            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Accounts/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};

            JObject jsonResponse = await JObject.LoadAsync(reader)
                .ConfigureAwait(false);

            Guid.TryParse(jsonResponse["accounts"]![0]!["accountId"]!.Value<string>(), out Guid accountId);
            decimal.TryParse(jsonResponse["accounts"]![0]!["currentBalance"]!.Value<string>(),
                out decimal currentBalance);

            return new Tuple<Guid, decimal>(accountId, currentBalance);
        }

        private async Task<Tuple<Guid, decimal>> GetAccount(string accountId)
        {
            HttpClient client = this._factory.CreateClient();
            string actualResponseString = await client
                .GetStringAsync($"/api/v1/Accounts/{accountId}")
                .ConfigureAwait(false);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};

            JObject jsonResponse = await JObject.LoadAsync(reader)
                .ConfigureAwait(false);

            Guid.TryParse(jsonResponse["account"]!["accountId"]!.Value<string>(), out Guid getAccountId);
            decimal.TryParse(jsonResponse["account"]!["currentBalance"]!.Value<string>(), out decimal currentBalance);

            return new Tuple<Guid, decimal>(getAccountId, currentBalance);
        }

        private async Task Deposit(string account, decimal amount)
        {
            HttpClient client = this._factory.CreateClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("amount", amount.ToString(CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("currency", "USD")
            });

            HttpResponseMessage response = await client.PatchAsync($"api/v1/Transactions/{account}/Deposit", content)
                .ConfigureAwait(false);

            string result = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task Withdraw(string account, decimal amount)
        {
            HttpClient client = this._factory.CreateClient();

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("amount", amount.ToString(CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("currency", "USD")
            });

            HttpResponseMessage response = await client.PatchAsync($"api/v1/Transactions/{account}/Withdraw", content)
                .ConfigureAwait(false);

            string responseBody = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task Close(string account)
        {
            HttpClient client = this._factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync($"api/v1/Accounts/{account}")
                .ConfigureAwait(false);

            string responseBody = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAccount_Withdraw_Deposit_Withdraw_Withdraw_Close()
        {
            Tuple<Guid, decimal> account = await this.GetAccounts()
                .ConfigureAwait(false);
            await this.GetAccount(account.Item1.ToString())
                .ConfigureAwait(false);
            await this.Withdraw(account.Item1.ToString(), account.Item2)
                .ConfigureAwait(false);
            await this.Deposit(account.Item1.ToString(), 500)
                .ConfigureAwait(false);
            await this.Deposit(account.Item1.ToString(), 300)
                .ConfigureAwait(false);
            await this.Withdraw(account.Item1.ToString(), 400)
                .ConfigureAwait(false);
            await this.Withdraw(account.Item1.ToString(), 400)
                .ConfigureAwait(false);
            account = await this.GetAccounts()
                .ConfigureAwait(false);
            await this.Close(account.Item1.ToString())
                .ConfigureAwait(false);
        }
    }
}
