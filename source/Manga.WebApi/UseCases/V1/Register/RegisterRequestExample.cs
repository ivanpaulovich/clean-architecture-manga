using Swashbuckle.AspNetCore.Examples;

namespace Manga.WebApi.UseCases.V1.Register
{
    public sealed class GetCustomerDetailsRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new RegisterRequest()
            {
                Name = "Ivan",
                InitialAmount = 600.50M,
                SSN = "198608179999"
            };

            return request;
        }
    }
}