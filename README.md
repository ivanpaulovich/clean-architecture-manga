![Manga](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/manga-icon.png) Clean Architecture Service Template with TDD/DDD
=========
[![Manga latest Docker build](https://dockerbuildbadges.quelltext.eu/status.svg?organization=ivanpaulovich&repository=manga)](https://hub.docker.com/r/ivanpaulovich/manga/) [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/ivanpaulovich/) [![Build status](https://ci.appveyor.com/api/projects/status/0i6s33kw3y87tkb2?svg=true)](https://ci.appveyor.com/project/ivanpaulovich/clean-architecture-manga) [![codecov](https://codecov.io/gh/ivanpaulovich/clean-architecture-manga/branch/master/graph/badge.svg)](https://codecov.io/gh/ivanpaulovich/clean-architecture-manga)

Manga is a Service Template to help you to build evolvable, adaptable and maintainable applications. It follows the Clean Architecture Principles (Robert C. Martin, 2017) and Domain-Driven Design. Tests guided us on the implementation so all the components are testable in isolation.

## :star: Generate your Microservice

Simple run:

```sh
dotnet new -i Paulovich.Manga
dotnet new manga
```

## :lemon: Compiling from source

To run Manga from source, clone this repository to your machine, compile and test it:

```sh
git clone https://github.com/ivanpaulovich/clean-architecture-manga.git
cd clean-architecture-manga/manga/build
./build.sh
```

## :clapper: The Clean Architecture

Unfortunately remain very common that applications are built on top of frameworks and databases. I see that developers usually implement software that mimics the data tables instead of design software driven by the business domain. As time goes by, the software becomes highly coupled to these external details and what happens next is the application evolution been dictated by the vendors support.

Hexagonal Architecture (aka Ports and Adapters) is one strategy to decouple the use cases from the external details. It was coined by Alistar Cockburn more than 13 years ago, and this received improvements with the Onion and Clean Architectures.

Let me introduce the Hexagonal Architectures's intent:

> Allow an application to equally be driven by users, programs or tests, and to be developed and tested in isolation from any of its eventual run-time devices and databases.

I need to point out that **Business Rules and Use Cases** should be implemented inside the Application Layer and they need to be maintained for the project’s life, in the other hand everything that give support for external capabilities are just **external details**, they can be replaced for different reasons, and we do not want the business rules to be coupled to them.

It is important to distinguish between the business and the details.

## :scissors: Business Rules and Use Cases
The business rules are the fine grained rules, they encapsulate entity fields and constraints. Also the business rules are the use cases that interacts with multiple entities and services. They together creates a process in the application, they should be sustained for a long time.

If the difference remain not clear, this Uncle Bob quote will clarify:

> Business Rules would make or save the business money, irrespective of whether they were implemented on a computer. They would make or save money even if they were executed manually.

In the DDD age, we have patterns to describe the business rules with Entities, Value Objects, Aggregates, Domain Services and so on. They are a perfect match with Hexagonal Architecture.

## :musical_keyboard: External Details
In most scenarios we can defer the implementation of external details and still keep the development progress. If your answer is yes for any of the next questions, you are probably dealing with peripheral details:

- Does the application needs an database to persist state?
- Does the application requires an User Interface?
- Does the application consumes an external API?

These are common external details which can be mocked, faked or their concrete implementation be replaced for different reasons. I suggest you to defer their implementation while you discover more of the domain. Keep in mind the Uncle Bob’s quote:

> A good architecture allows major decisions to be deferred and a good architect maximize the number of decisions not made.

Visual Studio makes it easy to add libraries for Reflection, Serialization, Security and many others Nuget packages in our projects.  The problem begin when we add these libraries to our Application and Domain. These libraries are just details and should be left out of the Application Layer.

What we should do?

- Stop going for shinning frameworks.
- Stop writing classes with inheritance from frameworks.
- Focus on the business rules, make them clear on your Application and Domain Layers.
- Don’t fall into tooling traps like scaffolding.
- Create the appropriate abstraction for these peripheral concerns.

Moving on, there are design principles that you should understand before implementing the Hexagonal Architecture style.

## :lock: Dependency Inversion Principle (DIP)
In the next example, the DIP was applied when decoupling our Use Cases from the Repositories. It is important to understand this priciple as it was applied to decouple other stuff in our source code. Let’s remember the DIP then navigate through one example:

> High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

Let's see how I applied this principle in the next example:

![Domain Model](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/DIP-1-2.png)

On the left side we found in red an Layered Application where the DepositUseCase depends on the AccountSQLRepository implementation. It is a coupled way to write code. On the right side in blue, by adding an IAccountRepository and applying DIP then the AccountSQLRepository has its dependency pointing inwards.

- The DepositUseCase is the High-level module that do not depend on database details, instead it depends on IAccountRepository abstraction.
- The IAccountRepository is the abstraction that do not depend on database details.
- The AccountSQLRepository is the low-level module that depends on IAccountRepository abstraction.

The following listing of DepositUseCase with DIP:

```csharp
public sealed class DepositUseCase : IDepositUseCase
{
    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

    public DepositUseCase(
        IAccountReadOnlyRepository accountReadOnlyRepository,
        IAccountWriteOnlyRepository accountWriteOnlyRepository)
    {
        _accountReadOnlyRepository = accountReadOnlyRepository;
        _accountWriteOnlyRepository = accountWriteOnlyRepository;
    }

    public async Task<DepositOutput> Execute(Guid accountId, Amount amount)
    {
        Account account = await _accountReadOnlyRepository.Get(accountId);
        if (account == null)
            throw new AccountNotFoundException($"The account {accountId} does not exists or is already closed.");

        account.Deposit(amount);
        Credit credit = (Credit)account.GetLastTransaction();

        await _accountWriteOnlyRepository.Update(
            account,
            credit);

        DepositOutput output = new DepositOutput(
            credit,
            account.GetCurrentBalance());
        return output;
    }
}
```

That is the main idea behind Hexagonal Architecture, whenever our application requires an external service we use the Port (a simple interface) and we implement the Adapter behind the abstraction.

## :bell: Separation of Concerns (SoC)
Our application requires some external capabilities but the application is not concerned about their implementation details, only their abstractions are visible to the application layer. We apply SoC by creating boundaries around the Adapters and by allowing them to be developed and tested in isolation. It’s a good practice to have different packages for each Adapter implementation.

We could have an specific Adapter for an SQL Database and an specific Adapter for Azure Storage both could be replaced with little effort. That is the idea behind the Hexagonal Architecture, keep the options open as long as possible and the ability to rollback if necessary.

We can quote Uncle Bob’s Plugin Architecture, about the relationship between Visual Studio and Resharper. Not a single line of VS knows about Resharper, but Resharper is developed based on the Visual Studio abstractions. They are developed by different companies one in Seattle and another in Moscow and still running well together.

## :key: Hexagonal Architecture Style Characteristics
With this style we have:

- An independent Business Domain to embody the fine grained business rules.
- Use Cases interacting with the Domain and independent of external services.
- Interfaces providing ports.
- Adapters providing implementations of frameworks, data access and UI.
- Externally the user, other systems and services.

One way to explain the Hexagonal Architecture is by its shapes. Take a look at the following picture:

![Hexagonal](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/hexagonal-1.png)

- The blue potato shape at the center is the Domain Layer and there are reasons for it. Every business domain has its own rules, very specific business rules, that is the reason of its undefined shape. For example, I designed our Domain Layer with DDD Building Blocks.
- The application has an hexagonal shape because each of its sides has specifics protocols.
- The Ports and Adapters are implemented outside of the application as plugins.
- Externally we have other systems.
- The Hexagonal is splitted in left and right. On the left we implement the driving actors and on the right we implement the secondary actors.

The direction of the dependencies goes inwards the center, so the Domain Layer does not know the Application Layer but the Application Layer depends on the Domain, the same rule applies to the outer layers.

## :fire: Layers
Let’s describe the Dependency Diagram below:

![Layers](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/Untitled-Diagram-1.png)

- The Domain Layer is totally independent of other layers and frameworks.
- The Application Layer depends exclusively on the Domain Layer.
- The Application Layer is independent of frameworks, databases and UI.
- The UI Layer and the Infrastructure Layer provides implementations for the Application needs.
- The UI Layer depends on Application Layer and it loads the Infrastructure Layer by indirection.

We should pay attention that the Infrastructure Layer can have many concerns. I recommend to design the infrastructure in a way you can split it when necessary, particularly when you have distinct adapters with overlapping concerns.

It is important to highlight the dashed arrow from the UI Layer to the Infrastructure layer. That is the where **Dependency Injection** is implemented, the concretions are loaded closer to the Main function. And there is a single setting in a external file that decides all the dependencies to be loaded.

## :star: Application Layer
Let’s dig into the Application Business Rules implemented by the Use Cases in our Bounded Context. As said by Uncle Bob in his book Clean Architecture:

> Just as the plans for a house or a library scream about the use cases of those buildings, so should the architecture of a software application scream about the use cases of the application.

Use Cases implementations are first-class modules in the root of this layer. The shape of a Use Case is an Interactor object that receives an Input, do some work then pass the Output through the caller. That’s the reason I am an advocate of feature folders describing the use cases and inside them the necessary classes:

![Use Cases](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/Use-Cases.png)

At your first look of the solution folders, you can build an idea of the purpose of this software. It seems like it can manage your Banck Account, for example you can Deposit or Withdraw money. Following we see the communication between the layers:

![Use Cases](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/Clean-Architecture-Style.png)

The Application exposes an interface (Port) to the UI Layer and another interface (another Port) to the Infrastructure Layer. What have you seen until here is Enterprise + Application Business Rules enforced without frameworks dependencies or without database coupling. Every details has abstractions protecting the Business Rules to be coupled to tech stuff.

## :soccer: Adapters for the User Interface
Now we advance to the next layer, at the User Interface Layer we translate the input in a way that the Use Cases can understand, it is good practice to do not reuse entities in this layer because it could create coupling, the front-end has specific frameworks, other ways of creating its data structures, different presentation for each field and validation rules.

In our implementation we have the following feature folders for every use case:

![Use Cases](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/Web-Use-Cases.png)

- **Request**: a data structure for the user input (accountId and amount).
- A **Controller** with an Action: this component receives the DepositRequest, calls the appropriate Deposit Use Case which do some processing then pass the output through the Presenter instance.
- **Presenter**: it converters the Output to the Model.
- **Model**: this is the return data structure for MVC applications.

We must highlight that the Controller knows the Deposit Use Case and it is not interested about the Output, instead the Controller delegates the responsibility of generating a Model to the Presenter instance.

```csharp
[Route("api/[controller]")]
public class AccountsController : Controller
{
    private readonly IDepositUseCase _depositUseCase;
    private readonly Presenter _presenter;

    public AccountsController(
        IDepositUseCase depositUseCase,
        Presenter presenter)
    {
        _depositUseCase = depositUseCase;
        _presenter = presenter;
    }

    /// <summary>
    /// Deposit to an account
    /// </summary>
    [HttpPatch("Deposit")]
    public async Task<IActionResult> Deposit([FromBody]DepositRequest message)
    {
        var output = await _depositUseCase.Execute(message.AccountId, message.Amount);
        _presenter.Populate(output);
        return _presenter.ViewModel;
    }
}
```

An Presenter class is detailed bellow and it shows a conversion from the DepositOutput to two different ViewModels. One ViewModel for null Outputs and another ViewModel for successful deposits.

```csharp
public class Presenter
{
    public IActionResult ViewModel { get; private set; }

    public void Populate(DepositOutput output)
    {
        if (output == null)
        {
            ViewModel = new NoContentResult();
            return;
        }

        ViewModel = new ObjectResult(new CurrentAccountBalanceModel(
            output.Transaction.Amount,
            output.Transaction.Description,
            output.Transaction.TransactionDate,
            output.UpdatedBalance
        ));
    }
}
```

## :tractor: Adapters for the Infrastructure
Another external layer is the Infrastructure Layer that implements Data Access, Dependency Injection Framework (DI) and other frameworks specifics. In this example we have multiple data access implementations.

![Use Cases](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/docs/Infrastructure.png)

## :game_die: How and When the DI is configured
We group the DI by Modules, so we have an module for the Entity Framework Data Access that requires a connection string like this:

```csharp
public class Module : Autofac.Module
{
    public string ConnectionString { get; set; }

    protected override void Load(ContainerBuilder builder)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseSqlServer(ConnectionString);
        optionsBuilder.EnableSensitiveDataLogging(true);

        builder.RegisterType<Context>()
            .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
            .InstancePerLifetimeScope();

        //
        // Register all Types in EntityFrameworkDataAccess namespace
        //
        builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
            .Where(type => type.Namespace.Contains("EntityFrameworkDataAccess"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
```

There is others modules in the same code base and we can run using them by changing the autofac.entityframework.json, an convenient way to setup desired modules.

```javascript
{
  "defaultAssembly": "Manga.Infrastructure",
  "modules": [
    {
      "type": "Manga.Infrastructure.Modules.WebApiModule",
      "properties": {
      }
    },
    {
      "type": "Manga.Infrastructure.Modules.ApplicationModule",
      "properties": {
      }
    },
    {
      "type": "Manga.Infrastructure.InMemoryDataAccess.Module"
    }
  ]
}
```

The autofac.json in set on the very beginning in the Program.cs. As it should be!

## :orange_book: Conclusion
With Hexagonal Architecture you design a decoupled software that allows major decisions to be deferred, all business rules will be isolated from peripheral concerns. And you have the option to try different adapters with less effort.

## :octopus: Running the latest Docker Build

You can run the Docker container of this project with the following command:

```sh
$ docker run -p 8000:80 -d \
	-e modules__2__properties__ConnectionString=mongodb://10.0.75.1:27017 \
	--name manga \
	ivanpaulovich/manga:latest
```
Then navigate to http://localhost:8000/swagger and play with de Swagger.

## :cloud: Questions and Issues

I am happy to clarify the decisions I made in this project through the [Issues tab](https://github.com/ivanpaulovich/clean-architecture-manga/issues) so everyone will take benefit of the discussion.
