namespace Acerola.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Acerola.UI;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using Newtonsoft.Json.Linq;

    public class CustomerRegistration
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public CustomerRegistration()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile("autofac.json")
                    .AddEnvironmentVariables();
                })
                .ConfigureServices(services => services.AddAutofac());

            server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }

        [Fact]
        public async Task ListCustomers()
        {
            var response = await client.GetAsync("/api/Customers");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ListAccounts()
        {
            var response = await client.GetAsync("/api/Accounts");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Register_Then_GetDetails()
        {
            var command = new {
                pin = "08724050601",
                name = "Ivan Paulovich",
                initialAmount = "1200"
            };

            string postedData = JsonConvert.SerializeObject(command);
            StringContent content = new StringContent(postedData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Customers", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("customerId", responseString);

            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string result = await client.GetStringAsync("/api/Customers/" + customer["customerId"]);
        }
    }
}
