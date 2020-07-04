namespace ComponentTests.V1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WebApi Collection")]
    public sealed class RegisterTests
    {
        public RegisterTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;

        private readonly CustomWebApplicationFactoryFixture _fixture;

        [Fact]
        public async Task RegisterReturnCustomerAndAccounts()
        {
            HttpClient client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ssn", "8608179999"),
                new KeyValuePair<string, string>("initialAmount", "300.5")
            });

            HttpResponseMessage actualResponse = await client
                .PostAsync("api/v1/Customers", content)
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) { DateParseHandling = DateParseHandling.None };
            JObject jsonResponse = JObject.Load(reader);

            Assert.Equal(JTokenType.String, jsonResponse["customer"]["customerId"].Type);
            Assert.Equal(JTokenType.String, jsonResponse["customer"]["ssn"].Type);
            Assert.Equal(JTokenType.String, jsonResponse["customer"]["name"].Type);
            Assert.Equal(JTokenType.String, jsonResponse["accounts"][0]["accountId"].Type);
            Assert.Equal(JTokenType.Integer, jsonResponse["accounts"][0]["currentBalance"].Type);

            Assert.True(Guid.TryParse(jsonResponse["customer"]["customerId"].Value<string>(), out Guid _));
            Assert.Equal("8608179999", jsonResponse["customer"]["ssn"]);
            Assert.Equal("Ivan Paulovich", jsonResponse["customer"]["name"]);
            Assert.True(Guid.TryParse(jsonResponse["accounts"][0]["accountId"].Value<string>(), out Guid _));
            Assert.Equal(500, jsonResponse["accounts"][0]["currentBalance"]);
        }
    }
}
