# Manga: The Clean Architecture Sample Implementation with .NET Core :cyclone:
[![All Contributors](https://img.shields.io/badge/all_contributors-10-orange.svg?style=flat-square)](#contributors)
[![Build status](https://ci.appveyor.com/api/projects/status/0i6s33kw3y87tkb2?svg=true)](https://ci.appveyor.com/project/ivanpaulovich/clean-architecture-manga)

> TODO: Add High level architecture and use cases image

Sample implementation of the **Clean Architecture Principles with .NET Core**. Use cases as central organizing structure, decoupled from frameworks and technology details. Has small components that are developed and tested in isolation.

## Motivation

> Learn how to design modular applications.
>
> Explore the .NET Core tooling.

### Learn how to design modular applications

Learning how to design modular applications will help you become a better engineer. Designing modular applications is the holy grail of software architecture, in our industry it is hard to find engineers that know how to design applications which allows adding new features in a steady speed. 

### Explore the .NET Core tooling

.NET Core brings a sweet development environment, an extensible and cross-platform framework. We will explore the benefits of it in the infrastructure layer and we will reduce the importance of it in the domain. The same rule is applied for modern C# constructions.

### Learn from the open source community

This is continually updated, open source project.

[Contributions](#contributors-) are welcome!

## Contributing

> Learn from the community.

Feel free to submit pull requests to help:

* Fix errors
* Improve sections
* Add new sections
* Submit questions and bugs

## Index of Clean Architecture Manga

* [Use Cases Description](#use-cases-description)
  * [Register](#register)
  * [Deposit](#deposit)
  * [Transfer](#transfer)
  * [Withdraw](#withdraw)
  * [Get Customer Details](#get-customer-details)
  * [Get Account Details](#get-account-details)
  * [Close Account](#close-account)
* [Flow of Control](#register-flow-of-control)
  * [Register Flow of Control](#register-flow-of-control)
  * [Get Customer Details Flow of Control](#get-customer-details-flow-of-control)
* [Architecture Styles](#architecture-styles)
  * [Ports and Adapters Architecture Style](#ports-and-adapters-architecture-style)
  * [Onion Architecture Style](#onion-architecture-style)
  * [Clean Architecture Style](#clean-architecture-style)
* [Design Patterns](#design-patterns)
  * [Controller](#controller)
  * [ViewModel](#viewmodel)
  * [Presenter](#presenter)
    * [Standard Output](#standard-output)
    * [Error Output](#error-output)
    * [Alternative Output](#alternative-output)
  * [Value Object](#value-object)
  * [Entity](#entity)
  * [Aggregate Root](#aggregate-root)
  * [Repository](#repository)
  * [Unit of Work](#unit-of-work)
  * [Use Case](#use-case)
  * [First-Class Collections](#first-class-collections)
  * [Factory](#factory)
  * [Component](#component)
* [Separation of Concerns](#separation-of-concerns)
* [Encapsulation](#encapsulation)
* [Test-Driven Development TDD](#test-driven-development-tdd)
  * [Outside-In Approach](#outside-in-approach)
  * [Fakes](#fakes)
  * [Clean Tests](#clean-tests)
  * [xUnit](#xunit)
* [SOLID](#solid)
  * [Single Responsibilty Principle](#single-responsibility-principle)
  * [Open-Closed Principle](#open-closed-principle)
  * [Liskov Substituiton Principle](#liskov-substituition-principle)
  * [Interface Segregation Principle](#interface-segregation-principle)
  * [Dependency Inversion Principle](#dependency-inversion-principle)
* [.NET Core](#.net-core)
  * [.NET Core Web API](#.net-core-webapi)
    * [Swagger](#swagger)
    * [API Versioning](#api-versioning)
    * [Microsoft Extensions](#microsoft-extensions)
    * [Feature Flags](#feature-flags)
    * [Logging](#logging)
    * [Localizing](#Localizing)
    * [Data Annotations](#data-annotations)
    * [Authentication](#authentication)
    * [Authorization](#authorization)
  * [Entity Framework Core](#entity-framework-core)
    * [Add Migration](#add-migration)
    * [Update Database](#update-database)
  * [Environment Configurations](#environment-configurations)
* [DevOps](#devops)
    * [Running the Application Locally](#running-the-application-locally)
    * [Running the Tests Locally](#running-the-tests-locally)
    * [Continuous Integration](#continuous-integration)
    * [Continuous Delivery](#continuous-delivery)
    * [Continuous Deployment](#continuous-deployment)
* [Docker](#docker)
* [SQL Server](#sql-server)
* [Related Content and Projects](#related-content-and-projects)
  
## Use Cases Description

Application architecture is about usage, a good architecture screams the business use cases to the developer and framework concerns are implementation details. On **Manga** sample the user can `Register` an account then manage the balance with `Deposits` and `Withdrawals`.

### Register

An customer can register the account using his personal details.

### Deposit

The customer can deposit a positive amount.

### Transfer

The customer can transfer money from one account to another.

### Withdraw

A customer can withdraw money but not more that the current balance.

### Get Customer Details

Customer details with all accounts and transactions are returned.

### Get Account Details

Account details with transactions are returned.

### Close Account

Close an account, requires zero balance.

## Flow of Control

The flow of control begins in the controller, moves through the use case, and then winds up executing in the presenter.

### Register Flow of Control

1. An request in received by the `CustomersController` and an action `Post` is invoked.
2. The action creates an `RegisterInput` message and the `Register` use case is executed.
3. The `Register` use case creates a `Customer` and an `Account`. Repositories are called, the `RegisterOutput` message is built and sent to the `RegisterPresenter`.
4. The `RegisterPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.

![Register Flow of Control](https://github.com/ivanpaulovich/clean-architecture-manga/blob/master/register-flow-of-control.svg)

### Get Customer Details Flow of Control

1. An request in received by the `CustomersController` and an action `GetCustomer` is invoked.
2. The action creates an `GetCustomerDetailsInput` message and the `GetCustomerDetails` use case is executed.
3. The `GetCustomerDetails` use case asks the repositories about the `Customer` and the `Account`. It could call the `NotFound` or the `Default` port of the `GetCustomerDetailsPresenter` depending if it exists or not.
4. The `GetCustomerDetailsPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.

## Architecture Styles

Manga use ideas from popular architectural styles. They Ports and Adapters are the simplest one followed by the others, they complement each other and aim a software with use cases decoupled from implementation details.

### Ports and Adapters Architecture Style

The Ports and Adapters Architecture Style divides the application into **Application Core** and **Adapters** in which the adapters are interchangeable components developed and tested in isolation. The Application Core is loosely coupled to the Adapters and their implementation details.

### Onion Architecture Style

Very similar to Ports and Adapters, I would add that data objects cross boundaries as simple data structures. For instance, when the controller execute an use case it passes and immutable Input message. When the use cases calls an Presenter it gives a Output message (Data Transfer Objects if you like).

### Clean Architecture Style

An application architecture implementation guided by tests cases.

## Design Patterns

The following Design Patterns will help you continue implementing use cases in a consistent way. 

### Controller

Controllers receive Requests, build an Input message then call an Use Case, you should notice that the controller do not build the ViewModel, instead this responsibility is delegated to the presenter object.

```c#
public sealed class CustomersController : Controller
{
    
    // code omitted to simplify

    public async Task<IActionResult> Post([FromBody][Required] RegisterRequest request)
    {
        await _registerUseCase.Execute(new RegisterInput(
            new SSN(request.SSN),
            new Name(request.Name),
            new PositiveAmount(request.InitialAmount)));

        return _presenter.ViewModel;
    }
}
```

### ViewModel

ViewModels are data transfer objects, they will be rendered by the MVC framework so we need to follow the framework guidelines. I suggest that you add `[Required]` attributes so swagger generators could know the properties that are not nullable. My personal preference is to avoid getters here because you know how the response object will be created, so use the constructor.

```c#
/// <summary>
/// The response for Registration
/// </summary>
public sealed class RegisterResponse
{
    /// <summary>
    /// Customer ID
    /// </summary>
    [Required]
    public Guid CustomerId { get; }

    /// <summary>
    /// SSN
    /// </summary>
    [Required]
    public string SSN { get; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    public string Name { get; }

    /// <summary>
    /// Accounts
    /// </summary>
    [Required]
    public List<AccountDetailsModel> Accounts { get; }

    public RegisterResponse(
        Guid customerId,
        string ssn,
        string name,
        List<AccountDetailsModel> accounts)
    {
        CustomerId = customerId;
        SSN = ssn;
        Name = name;
        Accounts = accounts;
    }
}
```

### Presenter

Presenters build the Response objects when called by the application.

```c#
public sealed class RegisterPresenter : IOutputPort
{
    public IActionResult ViewModel { get; private set; }

    public void Error(string message)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = "An error occurred",
            Detail = message
        };

        ViewModel = new BadRequestObjectResult(problemDetails);
    }

    public void Standard(RegisterOutput output)
    {
        /// long object creation omitted

        ViewModel = new CreatedAtRouteResult("GetCustomer",
            new
            {
                customerId = model.CustomerId
            },
            model);
    }
}
```

It is important to understand that from the Application perspective the use cases see an OutputPort with custom methods to call dependent on the message, and from the Web Api perspective the Controller only see the ViewModel property.

#### Standard Output

The output port for the use case regular behavior.

#### Error Output

Called when an blocking errors happens.

#### Alternative Output

Called when an blocking errors happens.

### Value Object

Describe the tiny domain business rules. Objects that are unique by the has of their properties. Are immutable.

```c#
public sealed class Name : IEquatable<Name>
{
    private string _text;

    private Name() { }

    public Name(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new NameShouldNotBeEmptyException("The 'Name' field is required");

        _text = text;
    }

    public override string ToString()
    {
        return _text;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is string)
        {
            return obj.ToString() == _text;
        }

        return ((Name) obj)._text == _text;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + _text.GetHashCode();
            return hash;
        }
    }

    public bool Equals(Name other)
    {
        return this._text == other._text;
    }
}
```

### Entity

Objects that are unique by their IDs. Entities are mutable and instances of domain concepts.

### Aggregate Root

### Repository

### Unit of Work

### Use Case

## Test-Driven Development TDD

### Outside-In Approach

### Fakes

### Clean Tests

## SOLID

## Running from source

```
$ dotnet run --project "source/Manga.WebApi/Manga.WebApi.csproj"
```

### Development Environment

* MacOS Catalina :apple:
* Visual Studio Code :heart:
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)
* Docker :whale:
* SQL Server

### Setup SQL Server in Docker

<details><summary>Install SQL Server</summary>
<p>

To spin up a SQL Server in a docker container using the connection string `Server=localhost;User Id=sa;Password=<YourNewStrong!Passw0rd>;` run the following command:

```sh
$ ./source/scripts/sql-docker-up.sh
```

</p>
</details>

<details><summary>Update the Database</summary>
<p>

Generate tables and seed the database via Entity Framework Tool:

```sh
dotnet ef database update --project source/Manga.Infrastructure --startup-project source/Manga.WebApi
```

</p>
</details>

<details><summary>Add Migrations</summary>
<p>

Run the EF Tool to add a migration to the `Manga.Infrastructure` project.

```sh
$ dotnet ef migrations add "InitialCreate" -o "EntityFrameworkDataAccess/Migrations" --project source/Manga.Infrastructure --startup-project source/Manga.WebApi
```

</p>
</details>

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
<table>
  <tr>
    <td align="center"><a href="https://paulovich.net"><img src="https://avatars3.githubusercontent.com/u/7133698?v=4" width="100px;" alt="Ivan Paulovich"/><br /><sub><b>Ivan Paulovich</b></sub></a><br /><a href="#design-ivanpaulovich" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ivanpaulovich" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ivanpaulovich" title="Code">💻</a></td>
    <td align="center"><a href="https://spelos.net/"><img src="https://avatars3.githubusercontent.com/u/21304428?v=4" width="100px;" alt="Petr Sedláček"/><br /><sub><b>Petr Sedláček</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=petrspelos" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=petrspelos" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/luizgustavogp"><img src="https://avatars2.githubusercontent.com/u/5147169?v=4" width="100px;" alt="Gus"/><br /><sub><b>Gus</b></sub></a><br /><a href="#design-luizgustavogp" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=luizgustavogp" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/arulconsultant"><img src="https://avatars0.githubusercontent.com/u/47856951?v=4" width="100px;" alt="arulconsultant"/><br /><sub><b>arulconsultant</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=arulconsultant" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/guilhermeps"><img src="https://avatars1.githubusercontent.com/u/38736244?v=4" width="100px;" alt="Guilherme Silva"/><br /><sub><b>Guilherme Silva</b></sub></a><br /><a href="#design-guilhermeps" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=guilhermeps" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=guilhermeps" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/ostorc"><img src="https://avatars1.githubusercontent.com/u/13519594?v=4" width="100px;" alt="Ondřej Štorc"/><br /><sub><b>Ondřej Štorc</b></sub></a><br /><a href="#design-ostorc" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ostorc" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/MarlonMiranda"><img src="https://avatars3.githubusercontent.com/u/12774904?v=4" width="100px;" alt="Marlon Miranda da Silva"/><br /><sub><b>Marlon Miranda da Silva</b></sub></a><br /><a href="#design-MarlonMiranda" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=MarlonMiranda" title="Tests">⚠️</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/NicoCG"><img src="https://avatars1.githubusercontent.com/u/33652180?v=4" width="100px;" alt="NicoCG"/><br /><sub><b>NicoCG</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=NicoCG" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://stackoverflow.com/users/2072198/fals"><img src="https://avatars2.githubusercontent.com/u/3750960?v=4" width="100px;" alt="Filipe Augusto Lima de Souza"/><br /><sub><b>Filipe Augusto Lima de Souza</b></sub></a><br /><a href="#design-fals" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=fals" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=fals" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/sshaw-sml"><img src="https://avatars3.githubusercontent.com/u/33876744?v=4" width="100px;" alt="sshaw-sml"/><br /><sub><b>sshaw-sml</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sshaw-sml" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sshaw-sml" title="Code">💻</a></td>
  </tr>
</table>

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
