namespace EndToEndTests.V1
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("WebApi Collection")]
    public sealed class GetAccountsTests
    {
        public GetAccountsTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;

        private readonly CustomWebApplicationFactoryFixture _fixture;

        [Fact]
        public async Task GetAccountsReturnsList()
        {
            HttpClient client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Accounts/")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
        }
    }
}
