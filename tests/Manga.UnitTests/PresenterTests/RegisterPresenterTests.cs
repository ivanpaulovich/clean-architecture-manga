namespace Manga.UnitTests.PresenterTests
{
    using System;
    using System.Net;
    using Manga.Application.Boundaries.Register;
    using Manga.Domain.ValueObjects;
    using Manga.WebApi.UseCases.V1.Register;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public sealed class RegisterPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            var customer = new Domain.Customers.Customer(
                new SSN("198608179999"),
                new Name("Ivan")
            );

            var account = new Domain.Accounts.Account(
                Guid.NewGuid()
            );

            var registerOutput = new RegisterOutput(
                customer,
                account
            );

            var sut = new RegisterPresenter();
            sut.Handle(registerOutput);

            var actual = Assert.IsType<OkObjectResult>(sut.ViewModel);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);

            var actualValue = (RegisterResponse)actual.Value;
            Assert.Equal(customer.Id, actualValue.CustomerId);
        }
    }
}