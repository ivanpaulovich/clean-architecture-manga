# Manga: The Clean Architecture Sample Implementation with .NET Core :cyclone:
[![All Contributors](https://img.shields.io/badge/all_contributors-16-orange.svg?style=flat-square)](#contributors) [![Build Status](https://dev.azure.com/ivanpaulovich/clean-architecture-manga/_apis/build/status/ivanpaulovich.clean-architecture-manga?branchName=master)](https://dev.azure.com/ivanpaulovich/clean-architecture-manga/_build/latest?definitionId=20&branchName=master)

Sample implementation of the **Clean Architecture Principles with .NET Core**. Use cases as central organizing structure, decoupled from frameworks and technology details. Built with small components that are developed and tested in isolation.

**ProTip #1:** To get the Clean Architecture updates hit the `WATCH` button :eyes:.

**Manga** is a virtual Wallet application in which a customer can register an account then manage the balance with `Deposits`, `Withdraws` and `Transfers`.

The Manga's demo is hosted on `Azure` servers and the `Swagger UI` client is available at [https://clean-architecture-manga.azurewebsites.net/swagger/index.html](https://clean-architecture-manga.azurewebsites.net/swagger/). It is just beautiful!
[![Swagger Demo](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-swagger.png)](https://clean-architecture-manga.azurewebsites.net/swagger/index.html)


<p align="center">
  Run the Docker container in less than 2 minutes using Play With Docker:
  <br>
  <br>
  <a href="https://labs.play-with-docker.com/?stack=https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docker-compose.yml&amp;stack_name=clean-architecture-manga" rel="nofollow"><img src="https://raw.githubusercontent.com/play-with-docker/stacks/master/assets/images/button.png" alt="Try in PWD" style="max-width:100%;"></a>
</p>


## Motivation

> Learn how to design modular applications.
>
> Explore the .NET Core features.

### Learn how to design modular applications

Learning how to design modular applications will help you become a better engineer. Designing modular applications is the holy grail of software architecture, it is hard to find engineers experienced in designing applications which allows adding new features in a steady speed. 

### Explore the .NET Core features

.NET Core brings a sweet development environment, an extensible and cross-platform framework. We will explore the benefits of it in the infrastructure layer and we will reduce its relevance in the application layer. The same rule is applied for modern C# language constructions.

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

* [Use Cases](#use-cases)
* [Flow of Control](#register-flow-of-control)
  * [Register Flow of Control](#register-flow-of-control)
  * [Get Customer Details Flow of Control](#get-customer-details-flow-of-control)
* [Architecture Styles](#architecture-styles)
  * [Hexagonal Architecture Style](#ports-and-adapters-architecture-style)
    * [Ports](#ports)
    * [Adapters](#adapters)
    * [The Left Side](#the-left-side)
    * [The Right Side](#the-right-side)
  * [Onion Architecture Style](#onion-architecture-style)
  * [Clean Architecture Style](#clean-architecture-style)
* [Design Patterns](#design-patterns)
  * [Controller](#controller)
  * [ViewModel](#viewmodel)
  * [Presenter](#presenter)
    * [Standard Output](#standard-output)
    * [Error Output](#error-output)
    * [Alternative Output](#alternative-output)
  * [Unit of Work](#unit-of-work)
  * [First-Class Collections](#first-class-collections)
  * [Factory](#factory)
* [Domain-Driven Design Patterns](#domain-driven-design-patterns)
  * [Value Object](#value-object)
  * [Entity](#entity)
  * [Aggregate Root](#aggregate-root)
  * [Repository](#repository)
  * [Use Case](#use-case)
* [Separation of Concerns](#separation-of-concerns)
  * [Domain](#domain)
  * [Application](#application)
  * [Infrastructure](#infrastructure)
  * [User Interface](#user-interface)
* [Encapsulation](#encapsulation)
* [Test-Driven Development TDD](#test-driven-development-tdd)
  * [Fakes](#fakes)
* [SOLID](#solid)
  * [Single Responsibility Principle](#single-responsibility-principle)
  * [Open-Closed Principle](#open-closed-principle)
  * [Liskov Substitution Principle](#liskov-substitution-principle)
  * [Interface Segregation Principle](#interface-segregation-principle)
  * [Dependency Inversion Principle](#dependency-inversion-principle)
* [.NET Core Web API](#.net-core-webapi)
  * [Swagger and API Versioning](#swagger-and-api-versioning)
  * [Microsoft Extensions](#microsoft-extensions)
  * [Feature Flags](#feature-flags)
  * [Logging](#logging)
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
  * [Continuous Integration & Continuous Deployment](#continuous-integration-continuous-deployment)
* [Docker](#docker)
* [SQL Server](#sql-server)
* [Related Content and Projects](#related-content-and-projects)

**ProTip #2:** Really interested in designing modular applications? Support this project with a hit on the `STAR` button :star:. Share with a friend!
  
## Use Cases

> Use Cases are delivery independent, they show the intent of a system.
> 
> Use Cases are algorithms which interpret the input to generate the output data.

Application architecture is about usage, a good architecture screams the business use cases to the developer and framework concerns are implementation details. On **Manga** sample the user can `Register` an account then manage the balance by `Deposits`, `Withdrawals` and `Transfers`.

<p align="center">
  <img src="https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-use-cases.png" alt=Clean Architecture Use Cases" style="max-width:100%;">
</p>

Following the list of Use Cases:

| Use Case             | Description                                                           |
|----------------------|-----------------------------------------------------------------------|
| Register             | An customer can register an account using his personal details.       |
| Deposit              | The customer can deposit an amount.                                   |
| Transfer             | The customer can transfer money from one account to another.          |
| Withdraw             | A customer can withdraw money but not more that the current balance.  |
| Get Customer Details | Get customer details including all related accounts and transactions. |
| Get Account Details  | Get account details including transactions.                           |
| Close Account        | Closes an account, requires balance to be zero.                       |

## Flow of Control

The flow of control begins in the controller, moves through the use case, and then winds up executing in the presenter.

### Register Flow of Control

1. An request in received by the `CustomersController` and an action `Post` is invoked.
2. The action creates an `RegisterInput` message and the `Register` use case is executed.
3. The `Register` use case creates a `Customer` and an `Account`. Repositories are called, the `RegisterOutput` message is built and sent to the `RegisterPresenter`.
4. The `RegisterPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.

![Register Flow of Control](https://github.com/ivanpaulovich/clean-architecture-manga/blob/master/docs/register-flow-of-control.svg)

### Get Customer Details Flow of Control

1. An request in received by the `CustomersController` and an action `GetCustomer` is invoked.
2. The action creates an `GetCustomerDetailsInput` message and the `GetCustomerDetails` use case is executed.
3. The `GetCustomerDetails` use case asks the repositories about the `Customer` and the `Account`. It could call the `NotFound` or the `Default` port of the `GetCustomerDetailsPresenter` depending if it exists or not.
4. The `GetCustomerDetailsPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.

## Architecture Styles

Manga uses ideas from popular architectural styles. They Ports and Adapters are the simplest one followed by the others, they complement each other and aim a software made by use cases decoupled from technology implementation details.

### Hexagonal Architecture Style

The general idea behind Hexagonal architecture style is that the dependencies (Adapters) required by the software to run are used behind an interface (Port).  

The software is divided into **Application** and **Infrastructure** in which the adapters are interchangeable components developed and tested in isolation. The Application is loosely coupled to the Adapters and their implementation details.

#### Ports

Interfaces like `ICustomerRepository`, `IOutputPort` and `IUnitOfWork` are ports required by the application.

#### Adapters

The interface implementations, they are specific to a technology and bring external capabilities. For instance the `CustomerRepository` inside the `EntityFrameworkDataAccess` folder provides capabilities to consume an SQL Server database.

![Ports and Adapters](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-ports-and-adapters.png)

#### The Left Side

Primary Actors are usually the user interface or the Test Suit.

#### The Right Side

The Secondary Actors are usually Databases, Cloud Services or other systems.

### Onion Architecture Style

Very similar to Ports and Adapters, I would add that data objects cross boundaries as simple data structures. For instance, when the controller execute an use case it passes and immutable Input message. When the use cases calls an Presenter it gives a Output message (Data Transfer Objects if you like).

### Clean Architecture Style

An application architecture implementation guided by tests cases.

## Design Patterns

The following Design Patterns will help you continue implementing use cases in a consistent way.

### Controller

Controllers receive Requests, build the Input message then call the Use Case, you should notice that the controller do not build the Response, instead this responsibility is delegated to the presenter object.

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

ViewModels are data transfer objects, they will be rendered by the MVC framework so we need to follow the framework guidelines. I suggest that you add comments describing each property and the `[Required]` attribute so swagger generators could know the properties that are not nullable. My personal preference is to avoid getters here because you have total control of response object instantiation, so implement the constructor.

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

Presenters are called by te application Use Cases and build the Response objects.

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

### Unit of Work

```c#
public interface IUnitOfWork
{
    Task<int> Save();
}
```

```c#
public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private MangaContext context;

    public UnitOfWork(MangaContext context)
    {
        this.context = context;
    }

    public async Task<int> Save()
    {
        int affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    private bool disposed = false;

    private void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
```

### First-Class Collections

```c#
public sealed class CreditsCollection
{
    private readonly IList<ICredit> _credits;

    public CreditsCollection()
    {
        _credits = new List<ICredit>();
    }

    public void Add<T>(IEnumerable<T> credits)
        where T : ICredit
    {
        foreach (var credit in credits)
            Add(credit);
    }

    public void Add(ICredit credit)
    {
        _credits.Add(credit);
    }

    public IReadOnlyCollection<ICredit> GetTransactions()
    {
        var transactions = new ReadOnlyCollection<ICredit>(_credits);
        return transactions;
    }

    public PositiveAmount GetTotal()
    {
        PositiveAmount total = new PositiveAmount(0);

        foreach (ICredit credit in _credits)
        {
            total = credit.Sum(total);
        }

        return total;
    }
}
```

### Factory

```c#
public interface IEntityFactory
{
    ICustomer NewCustomer(SSN ssn, Name name);
    IAccount NewAccount(ICustomer customer);
    ICredit NewCredit(IAccount account, PositiveAmount amountToDeposit);
    IDebit NewDebit(IAccount account, PositiveAmount amountToWithdraw);
}
```

```c#
public sealed class EntityFactory : IEntityFactory
{
    public IAccount NewAccount(ICustomer customer)
    {
        var account = new Account(customer);
        return account;
    }

    public ICredit NewCredit(IAccount account, PositiveAmount amountToDeposit)
    {
        var credit = new Credit(account, amountToDeposit);
        return credit;
    }

    public ICustomer NewCustomer(SSN ssn, Name name)
    {
        var customer = new Customer(ssn, name);
        return customer;
    }

    public IDebit NewDebit(IAccount account, PositiveAmount amountToWithdraw)
    {
        var debit = new Debit(account, amountToWithdraw);
        return debit;
    }
}
```

### Component

## Domain-Driven Design Patterns

The following patterns are known to describe business solutions.

### Value Object

Describe the tiny domain business rules. Structures that are unique by the has of their properties. Are immutable.

Tips: The IEquatable interface is not necessary to perform an equality check
> The IEquatable interface is used by generic collection objects such as Dictionary<TKey,TValue>, List, and LinkedList when testing for equality in such methods as Contains, IndexOf, LastIndexOf, and Remove. It should be implemented for any object that might be stored in a generic collection.

```c#
public readonly struct Name
{
    private readonly string _text;

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
}
```

### Entity

Mutable objects unique identified by their IDs.

```c#
public class Credit : ICredit
{
    public Guid Id { get; protected set; }
    public PositiveAmount Amount { get; protected set; }
    public string Description
    {
        get { return "Credit"; }
    }
    public DateTime TransactionDate { get; protected set; }

    public PositiveAmount Sum(PositiveAmount amount)
    {
        return Amount.Add(amount);
    }
}
```

### Aggregate Root

Similar to Entities with the addition that Aggregate Root are responsible to keep the tree of objects consistent.

```c#
public class Account : IAccount
{
    public Guid Id { get; protected set; }
    public CreditsCollection Credits { get; protected set; }
    public DebitsCollection Debits { get; protected set; }

    protected Account()
    {
        Credits = new CreditsCollection();
        Debits = new DebitsCollection();
    }

    public ICredit Deposit(IEntityFactory entityFactory, PositiveAmount amountToDeposit)
    {
        var credit = entityFactory.NewCredit(this, amountToDeposit);
        Credits.Add(credit);
        return credit;
    }

    public IDebit Withdraw(IEntityFactory entityFactory, PositiveAmount amountToWithdraw)
    {
        if (GetCurrentBalance().LessThan(amountToWithdraw))
            return null;

        var debit = entityFactory.NewDebit(this, amountToWithdraw);
        Debits.Add(debit);
        return debit;
    }

    public bool IsClosingAllowed()
    {
        return GetCurrentBalance().IsZero();
    }

    public Amount GetCurrentBalance()
    {
        var totalCredits = Credits
            .GetTotal();

        var totalDebits = Debits
            .GetTotal();

        var totalAmount = totalCredits
            .Subtract(totalDebits);

        return totalAmount;
    }
}
```

### Repository

```c#
public sealed class CustomerRepository : ICustomerRepository
{
    private readonly MangaContext _context;

    public CustomerRepository(MangaContext context)
    {
        _context = context;
    }

    public async Task Add(ICustomer customer)
    {
        _context.Customers.Add((InMemoryDataAccess.Customer) customer);
        await Task.CompletedTask;
    }

    public async Task<ICustomer> Get(Guid id)
    {
        Customer customer = _context.Customers
            .Where(e => e.Id == id)
            .SingleOrDefault();

        return await Task.FromResult<Customer>(customer);
    }

    public async Task Update(ICustomer customer)
    {
        Customer customerOld = _context.Customers
            .Where(e => e.Id == customer.Id)
            .SingleOrDefault();

        customerOld = (Customer) customer;
        await Task.CompletedTask;
    }
}
```

### Use Case

```c#
public sealed class Withdraw : IUseCase
{
    // properties and constructor omitted

    public async Task Execute(WithdrawInput input)
    {
        IAccount account = await _accountRepository.Get(input.AccountId);
        if (account is null)
        {
            _outputHandler.Error($"The account {input.AccountId} does not exist or is already closed.");
            return;
        }

        IDebit debit = account.Withdraw(_entityFactory, input.Amount);

        if (debit is null)
        {
            _outputHandler.Error($"The account {input.AccountId} does not have enough funds to withdraw {input.Amount}.");
            return;
        }

        await _accountRepository.Update(account, debit);
        await _unitOfWork.Save();

        WithdrawOutput output = new WithdrawOutput(
            debit,
            account.GetCurrentBalance()
        );

        _outputHandler.Standard(output);
    }
}
```

## Separation of Concerns

<p align="center">
  <img src="https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-layers.png" alt="Layers" style="max-width:100%;">
</p>

### Domain

The package that contains the `High Level Modules` which describe the Domain via Aggregate Roots, Entities and Value Objects. By design this project is `Highly Abstract` and `Stable`, in other terms this package contains a considerable amount of interfaces and should not depend on external libraries and frameworks. Ideally it should be loosely coupled even to the .NET Framework.

### Application

A project that contains the Application Use Cases which orchestrate the high level business rules. By design the orchestration will depend on abstractions of external services (eg. Repositories). The package exposes Boundaries Interfaces (in other terms Contracts or `Ports`) which are used by the user interface.

### Infrastructure

The infrastructure layer is responsible to implement the `Adapters` to the `Secondary Actors`. For instance an SQL Server Database is a secondary actor which is affected by the application use cases, all the implementation and dependencies required to consume the SQL Server is created on infrastructure. By design the infrastructure depends on application layer.

### User Interface

The system entry point responsible to render an interface to interact with the User. Made with Controllers which receive HTTP Requests and Presenters which converts the application outputs into ViewModels that are rendered as HTTP Responses.

## Encapsulation

> Given a class, the sum of its members complexity should be less that the sum of its parts in isolation.

Suppose there is a `Customer` entity like this:

```c#
public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SSN { get; set; }
    public bool Active { get; set; }
    public string ActivatedBy { get; set; }
}
```

The complexity of the previous class is the same if there were variables like the following:

```c#
    Guid Id;
    string Name;
    string SSN;
    bool Active;
    string ActivatedBy;
```

Classes that are similar to a bag of data leaks unnecessary complexity. Consider reducing the complexity with something like:

```c#
public class Customer
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string SSN { get; protected set; }
    public bool Active { get; protected set; }
    public string ActivatedBy { get; protected set; }
}
```

## Test-Driven Development (TDD)

> You are not allowed to write any production code unless it is to make a failing unit test pass.
>
> You are not allowed to write any more of a unit test than is sufficient to fail; and compilation failures are failures.
>
> You are not allowed to write any more production code than is sufficient to pass the one failing unit test.

http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd

### Fakes

> Fake it till you make it

## SOLID

### Single Responsibility Principle

> A class should have one, and only one, reason to change.

### Open-Closed Principle

> You should be able to extend a classes behavior, without modifying it.

### Liskov Substitution Principle

> Derived classes must be substitutable for their base classes.

### Interface Segregation Principle

> Make fine grained interfaces that are client specific.

### Dependency Inversion Principle

> Depend on abstractions, not on concretions.

## .NET Core Web API

### Swagger and API Versioning

```c#
namespace WebApi.DependencyInjection
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebApi.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Examples;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class VersionedSwaggerExtensions
    {
        public static IServiceCollection AddVersionedSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'V'VVV");

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider()
                    .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var apiVersion in provider.ApiVersionDescriptions)
                {
                    ConfigureVersionedDescription(options, apiVersion);
                }

                var xmlCommentsPath = Assembly.GetExecutingAssembly()
                    .Location.Replace("dll", "xml");
                options.IncludeXmlComments(xmlCommentsPath);

                options.OperationFilter<ExamplesOperationFilter>();
                options.DocumentFilter<SwaggerDocumentFilter>();
            });

            return services;
        }

        private static void ConfigureVersionedDescription(
            SwaggerGenOptions options,
            ApiVersionDescription apiVersion)
        {
            var dictionairy = new Dictionary<string, string>
                { { "1.0", "This API features several endpoints showing different API features for API version V1" },
                    { "2.0", "This API features several endpoints showing different API features for API version V2" }
                };

            var apiVersionName = apiVersion.ApiVersion.ToString();
            options.SwaggerDoc(apiVersion.GroupName,
                new Info()
                {
                    Title = "Clean Architecture Manga",
                        Contact = new Contact()
                        {
                            Name = "@ivanpaulovich",
                                Email = "ivan@paulovich.net",
                                Url = "https://github.com/ivanpaulovich"
                        },
                        License = new License()
                        {
                            Name = "Apache License"
                        },
                        Version = apiVersionName,
                        Description = dictionairy[apiVersionName]
                });
        }

        public static IApplicationBuilder UseVersionedSwagger(
            this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
                {
                    if (httpRequest.Path.Value.Contains("/swagger"))
                    {
                        swaggerDoc.BasePath = httpRequest.Path.Value.Split("/").FirstOrDefault() ?? "";
                    }

                    if (httpRequest.Headers.TryGetValue("X-Forwarded-Prefix", out var xForwardedPrefix))
                    {
                        swaggerDoc.BasePath = xForwardedPrefix[0];
                    }
                });
            });

            app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}
```

### Microsoft Extensions

```c#
public sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureDevelopmentServices(IServiceCollection services)
    {
        services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddControllersAsServices();

        services.AddBusinessExceptionFilter();

        services.AddFeatureFlags(Configuration);
        services.AddVersionedSwagger();

        services.AddUseCases();
        services.AddInMemoryPersistence();
        services.AddPresentersV1();
        services.AddPresentersV2();
    }

    public void ConfigureProductionServices(IServiceCollection services)
    {
        services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddControllersAsServices();

        services.AddBusinessExceptionFilter();

        services.AddFeatureFlags(Configuration);
        services.AddVersionedSwagger();

        services.AddUseCases();
        services.AddSQLServerPersistence(Configuration);
        services.AddPresentersV1();
        services.AddPresentersV2();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseVersionedSwagger(provider);
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseMvc();
    }
}
```

### Feature Flags

```c#
public sealed class CustomControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private readonly IFeatureManager _featureManager;

    public CustomControllerFeatureProvider(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        for (int i = feature.Controllers.Count - 1; i >= 0; i--)
        {
            var controller = feature.Controllers[i].AsType();
            foreach (var customAttribute in controller.CustomAttributes)
            {
                if (customAttribute.AttributeType.FullName == typeof(FeatureGateAttribute).FullName)
                {
                    var constructorArgument = customAttribute.ConstructorArguments.First();
                    foreach (var argumentValue in constructorArgument.Value as IEnumerable)
                    {
                        var typedArgument = (CustomAttributeTypedArgument) argumentValue;
                        var typedArgumentValue = (Features) (int) typedArgument.Value;
                        if (!_featureManager.IsEnabled(typedArgumentValue.ToString()))
                            feature.Controllers.RemoveAt(i);
                    }
                }
            }
        }
    }
}
```

### Logging

```c#
public static IWebHostBuilder CreateWebHostBuilder(string[] args)
{
    return WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            var env = hostingContext.HostingEnvironment;

            config.AddJsonFile("appsettings.json", optional : true, reloadOnChange : true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional : true, reloadOnChange : true);

            config.AddEnvironmentVariables();

            if (args != null)
            {
                config.AddCommandLine(args);
            }
        })
        .ConfigureLogging((hostingContext, logging) =>
        {
            // Requires `using Microsoft.Extensions.Logging;`
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
            logging.AddEventSourceLogger();
        })
        .UseStartup(typeof(Program).Assembly.FullName);
}
```

```c#
public static class FeatureFlagsExtensions
{
    public static IServiceCollection AddFeatureFlags(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFeatureManagement(configuration);

        var featureManager = services.BuildServiceProvider()
            .GetRequiredService<IFeatureManager>();

        services.AddMvc()
            .ConfigureApplicationPartManager(apm =>
                apm.FeatureProviders.Add(
                    new CustomControllerFeatureProvider(featureManager)
                ));

        return services;
    }
}
```

```c#
public enum Features
{
    Transfer,
    GetAccountDetailsV2
}
```

### Data Annotations

Data Annotations are powerful tool from .NET, it can be interpreted by ASP.NET Core and other frameworks to generate Validation, User Interface and other things. On Manga project, Data Annotations are used to create a complete Swagger UI and HTTP Request validation. Of course following the Clean Architecture Principles we need to keep frameworks under control.

I decided to use Data Annotations on the User Interface layer. Take a look on the `RegisterRequest` class:

```c#
/// <summary>
/// Registration Request
/// </summary>
public sealed class RegisterRequest
{
    /// <summary>
    /// SSN
    /// </summary>
    [Required]
    public string SSN { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Initial Amount
    /// </summary>
    [Required]
    public decimal InitialAmount { get; set; }
}
```

The `RegisterResponse` also needs `[Required]` annotation for Swagger Clients.

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

References: [Designing and Testing Input Validation in .NET Core: The Clean Architecture way](https://paulovich.net/designing-testing-input-validation-in-dotnet-core-the-clean-architecture-way/)

## Entity Framework Core

```c#
public sealed class MangaContext : DbContext
{
    public MangaContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Credit> Credits { get; set; }
    public DbSet<Debit> Debits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .ToTable("Account");

        modelBuilder.Entity<Account>()
            .Ignore(p => p.Credits)
            .Ignore(p => p.Debits);

        modelBuilder.Entity<Customer>()
            .ToTable("Customer")
            .Property(b => b.SSN)
            .HasConversion(
                v => v.ToString(),
                v => new SSN(v));
                
        modelBuilder.Entity<Customer>()
            .ToTable("Customer")
            .Property(b => b.Name)
            .HasConversion(
                v => v.ToString(),
                v => new Name(v));

        modelBuilder.Entity<Customer>()
            .Ignore(p => p.Accounts);

        modelBuilder.Entity<Debit>()
            .ToTable("Debit")
            .Property(b => b.Amount)
            .HasConversion(
                v => v.ToAmount().ToDecimal(),
                v => new PositiveAmount(v));

        modelBuilder.Entity<Credit>()
            .ToTable("Credit")
            .Property(b => b.Amount)
            .HasConversion(
                v => v.ToAmount().ToDecimal(),
                v => new PositiveAmount(v));

        modelBuilder.Entity<Customer>().HasData(
            new { Id = new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"), Name = new Name("Test User"), SSN = new SSN("19860817-9999") }
        );

        modelBuilder.Entity<Account>().HasData(
            new { Id = new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), CustomerId = new Guid("197d0438-e04b-453d-b5de-eca05960c6ae") }
        );

        modelBuilder.Entity<Credit>().HasData(
            new
            {
                Id = new Guid("f5117315-e789-491a-b662-958c37237f9b"),
                    AccountId = new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"),
                    Amount = new PositiveAmount(400),
                    Description = "Credit",
                    TransactionDate = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Debit>().HasData(
            new
            {
                Id = new Guid("3d6032df-7a3b-46e6-8706-be971e3d539f"),
                    AccountId = new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"),
                    Amount = new PositiveAmount(400),
                    Description = "Debit",
                    TransactionDate = DateTime.UtcNow
            }
        );
    }
}
```

### Add Migration

Run the EF Tool to add a migration to the `Infrastructure` project.

```sh
dotnet ef migrations add "InitialCreate" -o "EntityFrameworkDataAccess/Migrations" --project src/Infrastructure --startup-project src/WebApi
```

### Update Database

Generate tables and seed the database via Entity Framework Tool:

```sh
dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
```

## Environment Configurations

To run in `Development` mode use:

```sh
dotnet run --project "src/WebApi/WebApi.csproj" --Environment="Development"
```

It starts the application and call `ConfigureDevelopmentServices` method which runs the application using in memory persistence.

The second option is to run in `Production` mode:

```sh
dotnet run --project "src/WebApi/WebApi.csproj" --Environment="Production"
```

This command will call `ConfigureProductionServices` then use SQL Server repositories.

## DevOps

### Running the Application Locally

Manga is a cross-platform application, you can run it from Mac, Windows or Unix. To develop new features, you may use Visual Studio or Visual Studio Code :heart:.

The single requirement is to install the latest .NET Code SDK.

* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

We made available scripts to create and seed the database quickly via Docker.

Finally to run it locally use:

```sh
dotnet run --project "src/WebApi/WebApi.csproj"
```

### Running the Tests Locally

Run the following command at the root folder:

```sh
dotnet test
```

### Continuous Integration & Continuous Deployment

```yml
version: '1.0.{build}'
image: 
  - Ubuntu
environment:
  DOCKER_USER:
    secure: YnlezJhfKFUWo+E5/WCikQ==
  DOCKER_PASS:
    secure: iwibHSi3B80XJ3KjT1sAS1c66AsaOP3UFyUKKWrL1jo=
  HEROKU_USERNAME:
    secure: CUWu9AI7dgCvD7XMGYEDtb7XQlvkcOSuxpdaKdzOu/M=
  HEROKU_API_KEY:
    secure: XEo5yF9x7hReDhlb66Aj6xnk2HOFboVzNW6BLR1+shV7MP1DhRl8J+hHg8Do7OKl
  HEROKU_APP_NAME:
    secure: tKa7ydQJbbA+uovQNa5sBs9OcRWsCj71r4l9wvDG7/I=
services:
  - docker
dotnet_csproj:
  patch: true
  file: '**\*.csproj'
  version: '{version}'
build_script:
  - docker pull mcr.microsoft.com/mssql/server:2017-latest || true
  - docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest || true
  - sleep 10
  - docker exec -i sql1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<YourStrong!Passw0rd>' -Q 'ALTER LOGIN SA WITH PASSWORD="<YourNewStrong!Passw0rd>"' || true
  - dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
  - dotnet build
  - pushd src/WebApi/
  - dotnet pack --configuration Release
  - popd
test_script:
  - dotnet test test/UnitTests/UnitTests.csproj
  - dotnet test test/IntegrationTests/IntegrationTests.csproj
  - dotnet test test/AcceptanceTests/AcceptanceTests.csproj
deploy_script:
  - docker build -t ivanpaulovich/clean-architecture-manga:github .
  - docker login -u="$DOCKER_USER" -p="$DOCKER_PASS"
  - docker push ivanpaulovich/clean-architecture-manga:github
  - docker login --username=$HEROKU_USERNAME --password=$HEROKU_API_KEY registry.heroku.com
  - docker tag ivanpaulovich/clean-architecture-manga:github registry.heroku.com/$HEROKU_APP_NAME/web
  - docker push registry.heroku.com/$HEROKU_APP_NAME/web                
  - curl https://cli-assets.heroku.com/install.sh | sh
  - heroku container:release web -a $HEROKU_APP_NAME
```

## Docker

```sh
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/src/WebApi/out .
CMD export ASPNETCORE_URLS=http://*:$PORT && dotnet WebApi.dll
```

## SQL Server

To spin up a SQL Server in a docker container using the connection string `Server=localhost;User Id=sa;Password=<YourNewStrong!Passw0rd>;` run the following command:

```sh
./sql-docker-up.sh
```

## Related Content and Projects

| Video                                 | Date         |
|---------------------------------------|--------------|
| [Clean Architecture Essentials - Stockholm Software Crafstmanship Meetup](https://dev.to/ivanpaulovich/clean-architecture-essentials-5a0m)| November 11, 2019  |
| [Hexagonal and Clean Architecture styles. Same or Different?](https://www.youtube.com/watch?v=FNQbyZu-NAo)| Sep 16, 2019  |
| [Clean Architecture Essentials](https://www.youtube.com/watch?v=NjPjCxTIf4M)| Sep 13, 2019  |
| [Shinning Frameworks and DDD?!](https://www.youtube.com/watch?v=OmxBqmmhoHg)| Sep 12, 2019  |
| [Clean Architecture: The User Interface is a detail](https://www.youtube.com/watch?v=lWH_ZDu2zKQ)| Sep 11, 2019  |
| [TDD and Hexagonal Architecture: Clean Tests](https://www.youtube.com/watch?v=j6_XPsqjrhE)| Sep 10, 2019  |
| [Designing and Testing Input Validation with .NET Core: The Clean Architecture way](https://www.youtube.com/watch?v=hyW4d5OcExw)| Sep 9, 2019  |
| [Clean Architecture Manga](https://www.youtube.com/watch?v=ivAkdJmSqLQ)              | Aug 6, 2019  |
| [TDD and TDD with .NET Core and VSCode](https://www.youtube.com/watch?v=ORe0r4bpfac&t=360s) | Nov 3, 2018  |
| [Introduction to Clean Architecture](https://www.youtube.com/watch?v=6SeoWIIK1NU&t=50s)    | Oct 31, 2018 |

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://paulovich.net"><img src="https://avatars3.githubusercontent.com/u/7133698?v=4" width="100px;" alt="Ivan Paulovich"/><br /><sub><b>Ivan Paulovich</b></sub></a><br /><a href="#design-ivanpaulovich" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ivanpaulovich" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ivanpaulovich" title="Code">💻</a></td>
    <td align="center"><a href="https://spelos.net/"><img src="https://avatars3.githubusercontent.com/u/21304428?v=4" width="100px;" alt="Petr Sedláček"/><br /><sub><b>Petr Sedláček</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=petrspelos" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=petrspelos" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/luizgustavogp"><img src="https://avatars2.githubusercontent.com/u/5147169?v=4" width="100px;" alt="Gus"/><br /><sub><b>Gus</b></sub></a><br /><a href="#design-luizgustavogp" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=luizgustavogp" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/arulconsultant"><img src="https://avatars0.githubusercontent.com/u/47856951?v=4" width="100px;" alt="arulconsultant"/><br /><sub><b>arulconsultant</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=arulconsultant" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/guilhermeps"><img src="https://avatars1.githubusercontent.com/u/38736244?v=4" width="100px;" alt="Guilherme Silva"/><br /><sub><b>Guilherme Silva</b></sub></a><br /><a href="#design-guilhermeps" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=guilhermeps" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=guilhermeps" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/ostorc"><img src="https://avatars1.githubusercontent.com/u/13519594?v=4" width="100px;" alt="Ondřej Štorc"/><br /><sub><b>Ondřej Štorc</b></sub></a><br /><a href="#design-ostorc" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ostorc" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/MarlonMiranda"><img src="https://avatars3.githubusercontent.com/u/12774904?v=4" width="100px;" alt="Marlon Miranda da Silva"/><br /><sub><b>Marlon Miranda da Silva</b></sub></a><br /><a href="#design-MarlonMiranda" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=MarlonMiranda" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/NicoCG"><img src="https://avatars1.githubusercontent.com/u/33652180?v=4" width="100px;" alt="NicoCG"/><br /><sub><b>NicoCG</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=NicoCG" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://stackoverflow.com/users/2072198/fals"><img src="https://avatars2.githubusercontent.com/u/3750960?v=4" width="100px;" alt="Filipe Augusto Lima de Souza"/><br /><sub><b>Filipe Augusto Lima de Souza</b></sub></a><br /><a href="#design-fals" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=fals" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=fals" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/sshaw-sml"><img src="https://avatars3.githubusercontent.com/u/33876744?v=4" width="100px;" alt="sshaw-sml"/><br /><sub><b>sshaw-sml</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sshaw-sml" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sshaw-sml" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/matheusneder"><img src="https://avatars1.githubusercontent.com/u/6011646?v=4" width="100px;" alt="Matheus Neder"/><br /><sub><b>Matheus Neder</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=matheusneder" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/matiienkodimitri"><img src="https://avatars2.githubusercontent.com/u/53822759?v=4" width="100px;" alt="димитрий матиенко"/><br /><sub><b>димитрий матиенко</b></sub></a><br /><a href="#design-matiienkodimitri" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=matiienkodimitri" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/morphlogic"><img src="https://avatars1.githubusercontent.com/u/29184473?v=4" width="100px;" alt="morphlogic"/><br /><sub><b>morphlogic</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=morphlogic" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=morphlogic" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/felpasl"><img src="https://avatars3.githubusercontent.com/u/5658895?v=4" width="100px;" alt="Felipe Lambert"/><br /><sub><b>Felipe Lambert</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=felpasl" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=felpasl" title="Code">💻</a></td>
    <td align="center"><a href="https://matray.website"><img src="https://avatars2.githubusercontent.com/u/9035444?v=4" width="100px;" alt="Philippe Matray"/><br /><sub><b>Philippe Matray</b></sub></a><br /><a href="#design-phmatray" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=phmatray" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/leandrofagundes"><img src="https://avatars1.githubusercontent.com/u/10363927?v=4" width="100px;" alt="Leandro Fagundes"/><br /><sub><b>Leandro Fagundes</b></sub></a><br /><a href="#question-leandrofagundes" title="Answering Questions">💬</a></td>
    <td align="center"><a href="https://github.com/bommen"><img src="https://avatars2.githubusercontent.com/u/52955252?v=4" width="100px;" alt="Bart van Ommen"/><br /><sub><b>Bart van Ommen</b></sub></a><br /><a href="#ideas-bommen" title="Ideas, Planning, & Feedback">🤔</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=bommen" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!

**ProTip #3:** Would you like to show Clean Architecture on your GitHub profile? Hit the `FORK` button :hearts:.
