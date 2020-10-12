namespace ComponentTests.V2
{
    using System;
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

        private async Task GetAccount(string accountId)
        {
            HttpClient client = this._factory.CreateClient();
            await client.GetAsync($"/api/v2/Accounts/{accountId}")
                .ConfigureAwait(false);
        }

        [Fact]
        public async Task GetAccounts_GetAccount()
        {
            Tuple<Guid, decimal> account = await this.GetAccounts()
                .ConfigureAwait(false);
            await this.GetAccount(account.Item1.ToString())
                .ConfigureAwait(false);
        }
    }
}
