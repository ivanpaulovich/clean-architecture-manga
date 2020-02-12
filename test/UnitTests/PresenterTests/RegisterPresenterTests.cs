namespace UnitTests.PresenterTests
{
    using System.Net;
    using Application.Boundaries.Register;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UseCases.V1.Register;
    using Xunit;
    using Account = Infrastructure.InMemoryDataAccess.Account;
    using Customer = Infrastructure.InMemoryDataAccess.Customer;

    public sealed class RegisterPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            var customer = new Customer(
                new SSN("198608178888"),
                new Name("Ivan Paulovich"));

            var account = new Account(
                customer.Id);

            var registerOutput = new RegisterOutput(
                new ExternalUserId("github/ivanpaulovich"),
                customer,
                account);

            var sut = new RegisterPresenter();
            sut.Standard(registerOutput);

            var actual = Assert.IsType<CreatedAtRouteResult>(sut.ViewModel);
            Assert.Equal((int)HttpStatusCode.Created, actual.StatusCode);

            var actualValue = (RegisterResponse)actual.Value;
            Assert.Equal(customer.Id.ToGuid(), actualValue.CustomerId);
        }
    }
}
