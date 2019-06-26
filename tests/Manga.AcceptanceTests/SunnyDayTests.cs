namespace Manga.AcceptanceTests
{
    using Manga.WebApi;
    using Xunit;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using System;
    using Microsoft.AspNetCore.Mvc.Testing;

    public sealed class SunnyDayTests : IClassFixture<WebApplicationFactory<StartupDevelopment>>
    {
        private readonly WebApplicationFactory<StartupDevelopment> _factory;

        public SunnyDayTests(WebApplicationFactory<StartupDevelopment> factory)
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
            string result = await client.GetStringAsync("/api/Customers/" + customerId);
        }

        private async Task GetAccount(string accountId)
        {
            var client = _factory.CreateClient();
            string result = await client.GetStringAsync("/api/Accounts/" + accountId);
        }

        private async Task<Tuple<string, string>> Register(double initialAmount)
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

            var response = await client.PostAsync("api/Customers", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("customerId", responseString);
            JObject customer = JsonConvert.DeserializeObject<JObject>(responseString);

            string customerId = customer["customerId"].Value<string>();
            string accountId = ((JContainer)customer["accounts"]).First["accountId"].Value<string>();

            return new Tuple<string, string>(customerId, accountId);
        }

        private async Task Deposit(string account, double amount)
        {
            var client = _factory.CreateClient();
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
            var client = _factory.CreateClient();
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
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/Accounts/" + account);
            response.EnsureSuccessStatusCode();
        }
    }
}