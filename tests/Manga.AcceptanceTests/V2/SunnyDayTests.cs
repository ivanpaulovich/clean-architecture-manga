namespace Manga.AcceptanceTests.V2
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using Manga.WebApi;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using Xunit;

    public sealed class SunnyDayTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SunnyDayTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
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
            var client = _factory.CreateClient();
            string result = await client.GetStringAsync($"/api/v1/Customers/{customerId}/?api-version=1");
        }

        private async Task GetAccount(string accountId)
        {
            var client = _factory.CreateClient();
            string result = await client.GetStringAsync($"/api/v2/AccountsV2/{accountId}/?api-version=2");
        }

        private async Task<Tuple<string, string>> Register(decimal initialAmount)
        {
            var client = _factory.CreateClient();
            var register = new
            {
                ssn = "8608179999",
                name = "Ivan Paulovich",
                initialAmount = initialAmount
            };

            string registerData = JsonConvert.SerializeObject(register);
            StringContent content = new StringContent(registerData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/v1/Customers?api-version=1", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("customerId", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string customerId = customer["customerId"].Value<string>();
            string accountId = ((JContainer) customer["accounts"]).First["accountId"].Value<string>();

            return new Tuple<string, string>(customerId, accountId);
        }

        private async Task Deposit(string account, decimal amount)
        {
            var client = _factory.CreateClient();
            var json = new
            {
                accountId = account,
                amount = amount,
            };

            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("api/v1/Accounts/Deposit?api-version=1", content);
            string result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        private async Task Withdraw(string account, decimal amount)
        {
            var client = _factory.CreateClient();
            var json = new
            {
                accountId = account,
                amount = amount,
            };

            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync("api/v1/Accounts/Withdraw?api-version=1", content);
            string result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        private async Task Close(string account)
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/v1/Accounts/{account}?api-version=1");
            response.EnsureSuccessStatusCode();
        }
    }
}
