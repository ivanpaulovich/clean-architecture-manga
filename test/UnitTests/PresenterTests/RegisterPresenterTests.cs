namespace UnitTests.PresenterTests
{
    using System.Net;
    using Application.Boundaries.Register;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UseCases.V1.Register;
    using Xunit;

    public sealed class RegisterPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            var customer = new Infrastructure.InMemoryDataAccess.Customer(
                new SSN("198608178888"),
                new Name("Ivan Paulovich"));

            var account = new Infrastructure.InMemoryDataAccess.Account(
                customer);

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
