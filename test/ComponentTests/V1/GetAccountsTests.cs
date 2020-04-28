namespace ComponentTests.V1
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WebApi Collection")]
    public sealed class GetAccountsTests
    {
        private readonly CustomWebApplicationFactoryFixture _fixture;

        public GetAccountsTests(CustomWebApplicationFactoryFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public async Task GetAccountsReturnsList()
        {
            var client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            var actualResponse = await client
                .GetAsync("/api/v1/Accounts/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);

            using var stringReader = new StringReader(actualResponseString);
            using var reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};
            var jsonResponse = JObject.Load(reader);

            Assert.Equal(JTokenType.String, jsonResponse["accounts"][0]["accountId"].Type);
            Assert.Equal(JTokenType.Integer, jsonResponse["accounts"][0]["currentBalance"].Type);

            Assert.True(Guid.TryParse(jsonResponse["accounts"][0]["accountId"].Value<string>(), out Guid _));
            Assert.True(Decimal.TryParse(jsonResponse["accounts"][0]["currentBalance"].Value<string>(), out decimal _));
        }
    }
}
