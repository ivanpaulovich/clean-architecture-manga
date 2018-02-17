namespace Manga.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Manga.UI;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using System;

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
        public async Task Register_Deposit_Withdraw_Close()
        {
            Tuple<string, string> customerId_accountId = await Register(100);
            await GetCustomer(customerId_accountId.Item1);
            await GetAccount(customerId_accountId.Item2);
            await Withdraw(customerId_accountId.Item2, 100);
            await GetCustomer(customerId_accountId.Item1);
            await Deposit(customerId_accountId.Item2, 500);
            await Deposit(customerId_accountId.Item2, 400);
            await GetCustomer(customerId_accountId.Item1);
            await Withdraw(customerId_accountId.Item2, 400);
            await Withdraw(customerId_accountId.Item2, 500);
            await Close(customerId_accountId.Item2);
        }

        private async Task GetCustomer(string customerId)
        {
            string result = await client.GetStringAsync("/api/Customers/" + customerId);
        }

        private async Task GetAccount(string accountId)
        {
            string result = await client.GetStringAsync("/api/Accounts/" + accountId);
        }

        private async Task<Tuple<string, string>> Register(double initialAmount)
        {
            var register = new
            {
                pin = "08724050601",
                name = "Ivan Paulovich",
                initialAmount = initialAmount
            };

            string registerData = JsonConvert.SerializeObject(register);
            StringContent content = new StringContent(registerData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Customers", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("customerId", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string customerId = customer["customerId"].Value<string>();
            string accountId = ((Newtonsoft.Json.Linq.JContainer)customer["accounts"]).First["accountId"].Value<string>();

            return new Tuple<string, string>(customerId, accountId);
        }

        private async Task Deposit(string account, double amount)
        {
            var json = new
            {
                accountId = account,
                amount = amount,
            };

            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("api/Accounts/Deposit", content);
            string result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        private async Task Withdraw(string account, double amount)
        {
            var json = new
            {
                accountId = account,
                amount = amount,
            };

            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("api/Accounts/Withdraw", content);
            string result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        private async Task Close(string account)
        {
            var response = await client.DeleteAsync("api/Accounts/" + account);
            response.EnsureSuccessStatusCode();
        }
    }

    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            var response = await client.SendAsync(request);
            return response;
        }
    }
}
