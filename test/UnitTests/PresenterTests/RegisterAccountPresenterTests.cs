namespace UnitTests.PresenterTests
{
    using System.Net;
    using Application.Boundaries.RegisterAccount;
    using Domain.ValueObjects;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UseCases.V1.RegisterAccount;
    using Xunit;

    public sealed class RegisterAccountPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            var customer = new Infrastructure.InMemoryDataAccess.Customer(
                new SSN("198608178888"),
                new Name("Ivan Paulovich"),
                new Username("ivanpaulovich"),
                new Password("password")
            );

            var account = new Infrastructure.InMemoryDataAccess.Account(
                customer
            );

            var registerOutput = new RegisterAccountOutput(
                customer,
                account
            );

            var sut = new RegisterAccountPresenter();
            sut.Standard(registerOutput);

            var actual = Assert.IsType<CreatedAtRouteResult>(sut.ViewModel);
            Assert.Equal((int) HttpStatusCode.Created, actual.StatusCode);

            var actualValue = (RegisterAccountResponse) actual.Value;
            Assert.Equal(customer.Id, actualValue.CustomerId);
        }
    }
}
