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
    public sealed class GetCustomerTests
    {
        private readonly CustomWebApplicationFactoryFixture _fixture;

        public GetCustomerTests(CustomWebApplicationFactoryFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public async Task GetCustomerReturnsCustomer()
        {
            var client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            var actualResponse = await client
                .GetAsync("/api/v1/Customers/")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            using var stringReader = new StringReader(actualResponseString);
            using var reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};
            var jsonResponse = JObject.Load(reader);

            Assert.Equal(JTokenType.String, jsonResponse["customer"]["customerId"].Type);
            Assert.Equal(JTokenType.String, jsonResponse["customer"]["ssn"].Type);
            Assert.Equal(JTokenType.String, jsonResponse["customer"]["name"].Type);

            Assert.True(Guid.TryParse(jsonResponse["customer"]["customerId"].Value<string>(), out Guid _));
            Assert.Equal("8608179999", jsonResponse["customer"]["ssn"]);
            Assert.Equal("Ivan Paulovich", jsonResponse["customer"]["name"]);
        }
    }
}
