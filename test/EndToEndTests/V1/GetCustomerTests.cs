namespace EndToEndTests.V1
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("WebApi Collection")]
    public sealed class GetCustomerTests
    {
        public GetCustomerTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;

        private readonly CustomWebApplicationFactoryFixture _fixture;

        [Fact]
        public async Task GetCustomerReturnsCustomer()
        {
            HttpClient client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Customers/")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
        }
    }
}
