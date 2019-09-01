# Manga: The Clean Architecture Sample Implementation with .NET Core :cyclone:
[![All Contributors](https://img.shields.io/badge/all_contributors-10-orange.svg?style=flat-square)](#contributors)
[![Build status](https://ci.appveyor.com/api/projects/status/0i6s33kw3y87tkb2?svg=true)](https://ci.appveyor.com/project/ivanpaulovich/clean-architecture-manga)

Sample implementation of the **Clean Architecture Principles with .NET Core**. Use cases as central organizing structure, decoupled from frameworks and technology details. Built with small components that are developed and tested in isolation. 

**ProTip:** To get the Clean Architecture updates hit the `WATCH` button :eyes:.

The Manga's swagger client is running on `Heroku` servers at [https://clean-architecture-manga.herokuapp.com/swagger/](https://clean-architecture-manga.herokuapp.com/swagger/) and the `Swagger UI` is just beautiful!
[![Swagger Demo](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-swagger.png)](https://clean-architecture-manga.herokuapp.com/swagger/index.html)


<p align="center">
  Also you can run the Docker container through:
  <br>
  <br>
  <a href="https://labs.play-with-docker.com/?stack=https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docker-compose.yml&amp;stack_name=clean-architecture-manga" rel="nofollow"><img src="https://raw.githubusercontent.com/play-with-docker/stacks/master/assets/images/button.png" alt="Try in PWD" style="max-width:100%;"></a>
</p>


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
  * [Unit of Work](#unit-of-work)
  * [First-Class Collections](#first-class-collections)
  * [Factory](#factory)
  * [Component](#component)
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
  * [Web](#web)
* [Encapsulation](#encapsulation)
* [Test-Driven Development TDD](#test-driven-development-tdd)
  * [Outside-In Approach](#outside-in-approach)
  * [Fakes](#fakes)
  * [Clean Tests](#clean-tests)
  * [xUnit](#xunit)
* [SOLID](#solid)
  * [Single Responsibility Principle](#single-responsibility-principle)
  * [Open-Closed Principle](#open-closed-principle)
  * [Liskov Substitution Principle](#liskov-substitution-principle)
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

> Use Cases are delivery independent, they show the intent of a system.
> 
> Use Cases are algorithms which interpret the input to generate the output data.

Application architecture is about usage, a good architecture screams the business use cases to the developer and framework concerns are implementation details. On **Manga** sample the user can `Register` an account then manage the balance by `Deposits`, `Withdrawals` and `Transfers`.

<p align="center">
  <img src="https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-use-cases.png" alt=Clean Architecture Use Cases" style="max-width:100%;">
</p>

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

![Register Flow of Control](https://github.com/ivanpaulovich/clean-architecture-manga/blob/master/docs/register-flow-of-control.svg)

### Get Customer Details Flow of Control

1. An request in received by the `CustomersController` and an action `GetCustomer` is invoked.
2. The action creates an `GetCustomerDetailsInput` message and the `GetCustomerDetails` use case is executed.
3. The `GetCustomerDetails` use case asks the repositories about the `Customer` and the `Account`. It could call the `NotFound` or the `Default` port of the `GetCustomerDetailsPresenter` depending if it exists or not.
4. The `GetCustomerDetailsPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.

## Architecture Styles

Manga uses ideas from popular architectural styles. They Ports and Adapters are the simplest one followed by the others, they complement each other and aim a software with use cases decoupled from implementation details.

### Ports and Adapters Architecture Style

The Ports and Adapters Architecture Style divides the application into **Application Core** and **Adapters** in which the adapters are interchangeable components developed and tested in isolation. The Application Core is loosely coupled to the Adapters and their implementation details.

![Ports and Adapters](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-ports-and-adapters.png)

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
        if (account == null)
        {
            _outputHandler.Error($"The account {input.AccountId} does not exist or is already closed.");
            return;
        }

        IDebit debit = account.Withdraw(_entityFactory, input.Amount);

        if (debit == null)
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

        _outputHandler.Default(output);
    }
}
```

## Separation of Concerns

<p align="center">
  <img src="https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/clean-architecture-manga-layers.png" alt="Layers" style="max-width:100%;">
</p>

### Domain

### Application

### Infrastructure

### Web

## Encapsulation

## Test-Driven Development TDD

### Outside-In Approach

### Fakes

### Clean Tests

### xUnit

## SOLID

### Single Responsibility Principle

### Open-Closed Principle

### Liskov Substitution Principle

### Interface Segregation Principle

### Dependency Inversion Principle

## .NET Core

### .NET Core Web API

#### Swagger

#### API Versioning

```c#
namespace Manga.WebApi.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Manga.WebApi.Filters;
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

#### Microsoft Extensions

#### Feature Flags

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

#### Logging

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

#### Localizing

#### Data Annotations

#### Authentication

#### Authorization

### Entity Framework Core

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
                v => v.ToAmount().ToDouble(),
                v => new PositiveAmount(v));

        modelBuilder.Entity<Credit>()
            .ToTable("Credit")
            .Property(b => b.Amount)
            .HasConversion(
                v => v.ToAmount().ToDouble(),
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

#### Add Migration

Run the EF Tool to add a migration to the `Manga.Infrastructure` project.

```sh
$ dotnet ef migrations add "InitialCreate" -o "EntityFrameworkDataAccess/Migrations" --project source/Manga.Infrastructure --startup-project source/Manga.WebApi
```

#### Update Database

Generate tables and seed the database via Entity Framework Tool:

```sh
dotnet ef database update --project source/Manga.Infrastructure --startup-project source/Manga.WebApi
```

### Environment Configurations

To run in `Development` mode use:

```bash
dotnet run --project "source/Manga.WebApi/Manga.WebApi.csproj" --Environment="Development"
```

It starts the application and call `ConfigureDevelopmentServices` method which runs the application using in memory persistence.

The second option is to run in `Production` mode:

```bash
dotnet run --project "source/Manga.WebApi/Manga.WebApi.csproj" --Environment="Production"
```

This command will call `ConfigureProductionServices` then use SQL Server repositories.

## DevOps

### Running the Application Locally

Manga is a cross-platform application, you can run it from Mac, Windows or Unix. To develop new features, you may use Visual Studio or Visual Studio Code :heart:.

The single requirement is to install the latest .NET Code SDK.

* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

We made available scripts to create and seed the database quickly via Docker.

Finally to run it locally use:

```
dotnet run --project "source/Manga.WebApi/Manga.WebApi.csproj"
```

### Running the Tests Locally

Run the following command at the root folder:

```
dotnet test
```

### Continuous Integration

### Continuous Delivery

### Continuous Deployment

## Docker

## SQL Server

To spin up a SQL Server in a docker container using the connection string `Server=localhost;User Id=sa;Password=<YourNewStrong!Passw0rd>;` run the following command:

```sh
$ ./source/scripts/sql-docker-up.sh
```

## Related Content and Projects

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
