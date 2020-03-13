namespace UnitTests.PresenterTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Application.Boundaries.Register;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Infrastructure.DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UseCases.V1.Register;
    using Xunit;
    using Account = Infrastructure.DataAccess.Entities.Account;

    public sealed class RegisterPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            var customer = new Customer(
                new CustomerId(Guid.NewGuid()),
                new Name("Ivan Paulovich"),
                new SSN("198608178888"));

            var account = new Account(
                new AccountId(Guid.NewGuid()),
                customer.Id);

            var user = new User(
                new ExternalUserId("github/ivanpaulovich"),
                new Name("Ivan Paulovich"),
                customer.Id);

            var registerOutput = new RegisterOutput(
                user,
                customer,
                new List<IAccount> {account});

            var sut = new RegisterPresenter();
            sut.Standard(registerOutput);

            var actual = Assert.IsType<CreatedAtRouteResult>(sut.ViewModel);
            Assert.Equal((int)HttpStatusCode.Created, actual.StatusCode);

            var actualValue = (RegisterResponse)actual.Value;
            Assert.Equal(customer.Id.ToGuid(), actualValue.Customer.CustomerId);
        }
    }
}
