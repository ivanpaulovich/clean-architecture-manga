# Clean Architecture with .NET Core & React+Redux :cyclone:
[![All Contributors](https://img.shields.io/badge/all_contributors-16-orange.svg?style=flat-square)](#contributors) [![Build Status](https://dev.azure.com/ivanpaulovich/clean-architecture-manga/_apis/build/status/ivanpaulovich.clean-architecture-manga?branchName=master)](https://dev.azure.com/ivanpaulovich/clean-architecture-manga/_build/latest?definitionId=20&branchName=master)

Sample implementation of the **Clean Architecture Principles with .NET Core**. Use cases as central organizing structure, decoupled from frameworks and technology details. Built by small components that are developed and tested in isolation.

We maintain two versions:

- [Latest .NET Core 3.1 release](https://github.com/ivanpaulovich/clean-architecture-manga) - Check the .NET Core SDK on `global.json`.
- [.NET 5](https://github.com/ivanpaulovich/clean-architecture-manga/tree/dotnet5) - Experimental features and .NET 5.

> Hit the `WATCH` button to get the latest Clean Architecture updates. <img src="https://emojis.slackmojis.com/emojis/images/1471045863/884/ninja.gif?1471045863" width="32" height="32" />

Manga is a Virtual Wallet software in which the customer register an account then manage the balance by `Deposits`, `Withdraws` and `Transfers`.

The Web API's demo is hosted on Azure servers and there's a beautiful [Swagger Client](https://clean-architecture-manga.azurewebsites.net/swagger/index.html) available.
[![Swagger Demo](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/docs/docs/clean-architecture-manga-swagger-v2.jpg)](https://clean-architecture-manga.azurewebsites.net/swagger/index.html)

We also support the React client:

[![React+Redux Demo](https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/docs/docs/clean-architecture-manga-react.png)](https://clean-architecture-manga.azurewebsites.net)


<p align="center">
  Run the Docker container in less than 2 minutes using Play With Docker:
  <br>
  <br>
  <a href="https://labs.play-with-docker.com/?stack=https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-manga/master/.docker/docker-compose.yml&amp;stack_name=clean-architecture-manga" rel="nofollow"><img src="https://raw.githubusercontent.com/play-with-docker/stacks/master/assets/images/button.png" alt="Try in PWD" style="max-width:100%;"></a>
</p>

## Build & Run

To startup the whole solution, execute the following command:

```sh
$ cd .docker; ./makecert.sh && ./trustcert.sh && sudo ./hostsadd.sh; popd;
$ cd .docker; ./startup.sh; popd;
```

Then the following containers should be running `docker ps`:

| Application 	    | URL |
|------------------ | -------------------------------------- |
| NGINX 	          | https://wallet.local:8081                   |
| Wallet SPA 	      | https://wallet.local:8081              |
| Accounts API 	    | https://wallet.local:8081/accounts-api      |
| Identity Server 	| https://wallet.local:8081/identity-server	  |
| SQL Server 	      | Server=localhost;User Id=sa;Password=<YourStrong!Passw0rd>;Database=Accounts; |

Browse to `https://wallet.local:8081` then click on Log In. Trust the [self-signed certificate](https://stackoverflow.com/questions/21397809/create-a-trusted-self-signed-ssl-cert-for-localhost-for-use-with-express-node).

If you prefer dotnet commands then start each service individually:

<details>
    <summary>Expand to get the dotnet run steps.</summary>

### Generate Self Signed Certificate

```sh
dotnet dev-certs https --clean
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p MyCertificatePassword
dotnet dev-certs https --trust
```

### Spin up SQL Server in a Docker container

```sh
docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-latest
```

### Create and Seed Accounts Database

```sh
dotnet tool update --global dotnet-ef --version 3.1.6
dotnet ef database update --project accounts-api/src/Infrastructure --startup-project accounts-api/src/WebApi
```

### Running Services

#### Identity Server

```sh
dotnet run --project identity-server/src/IdentityServer.csproj
```
#### Account API

```sh
dotnet run --project accounts-api/src/WebApi/WebApi.csproj
```

#### Wallett SPA

```sh
pushd wallet-spa/src/ClientApp
npm install
popd
dotnet run --project wallet-spa/src/WalletSPA.csproj --launch-profile WalletSPA
```

</details>

## Motivation

> Learn how to design modular applications.
>
> Explore the .NET Core features.

### Learn how to design modular applications

Learning how to design modular applications will help you become a better engineer. Designing modular applications is the holy grail of software architecture, it is hard to find engineers experienced on designing applications which allows adding new features in a steady speed.

### Explore the .NET Core features

.NET Core brings a sweet development environment, an extensible and cross-platform framework. We will explore the benefits of it in the infrastructure layer and we will reduce its importance in the application and domain layers. The same rule is applied for modern C# language syntax.

### Learn from the open source community

This is continually updated, open source project.

[Contributions](#contributors-) are welcome!

## Contributing

> Learn from the community.

Feel free to submit pull requests to help:

* Fix errors.
* Refactoring.
* Build the Front End.
* Submit issues and bugs.

> The [Discussão em Português](https://github.com/ivanpaulovich/clean-architecture-manga/issues/149) is pinned for the large community of brazillian developers. <img src="https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/320/twitter/248/flag-brazil_1f1e7-1f1f7.png" width="32" height="32" />

## Index of Clean Architecture Manga
### [Home](https://github.com/ivanpaulovich/clean-architecture-manga/wiki)
- [Motivation](https://github.com/ivanpaulovich/clean-architecture-manga/wiki#motivation)
  * [Learn how to design modular applications](https://github.com/ivanpaulovich/clean-architecture-manga/wiki#learn-how-to-design-modular-applications)
  * [Explore the .NET Core features](https://github.com/ivanpaulovich/clean-architecture-manga/wiki#explore-the-net-core-features)
  * [Learn from the open source community](https://github.com/ivanpaulovich/clean-architecture-manga/wiki#learn-from-the-open-source-community)
- [Contributing](https://github.com/ivanpaulovich/clean-architecture-manga/wiki#contributing)
### [Use Cases](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Use-Cases)
### [Flow of Control](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Flow-of-Control)
* [Register Flow of Control](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Flow-of-Control#register-flow-of-control)
* [Get Customer Details Flow of Control](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Flow-of-Control#get-customer-details-flow-of-control)
### [Architecture Styles](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles)
* [Hexagonal Architecture Style](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#ports-and-adapters-architecture-style)
  * [Ports](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#ports)
  * [Adapters](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#adapters)
  * [The Left Side](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#the-left-side)
  * [The Right Side](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#the-right-side)
* [Onion Architecture Style](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#onion-architecture-style)
* [Clean Architecture Style](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Architecture-Styles#clean-architecture-style)
### [Design Patterns](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns)
* [Controller](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller)
* [ViewModel](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#viewmodel)
* [Presenter](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#presenter)
    * [Standard Output](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#standard-output)
    * [Error Output](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#error-output)
    * [Alternative Output](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#alternative-output)
* [Unit of Work](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#unit-of-work)
* [First-Class Collections](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections)
* [Factory](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#factory)
### [Domain-Driven Design Patterns](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns)
* [Value Object](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object)
* [Entity](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity)
* [Aggregate Root](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#aggregate-root)
* [Repository](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#repository)
* [Use Case](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case)
### [Separation of Concerns](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Separation-of-Concerns#separation-of-concerns)
- [Domain](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Separation-of-Concerns#domain)
- [Application](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Separation-of-Concerns#application)
- [Infrastructure](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Separation-of-Concerns#infrastructure)
- [User Interface](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Separation-of-Concerns#user-interface)
### [Encapsulation](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Encapsulation)
### [Test-Driven Development TDD](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Test-Driven-Development)
### [Fakes](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Fakes)
### [SOLID](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/SOLID)
- [Single Responsibility Principle](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/SOLID#single-responsibility-principle)
- [Open-Closed Principle](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/SOLID#open-closed-principle)
- [Liskov Substitution Principle](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/SOLID#liskov-substitution-principle)
- [Interface Segregation Principle](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/SOLID#interface-segregation-principle)
- [Dependency Inversion Principle](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/SOLID#dependency-inversion-principle)
### [.NET Core Web API](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/.NET-Core-WebAPI#.net-core-webapi)
* [Swagger and API Versioning](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/.NET-Core-WebAPI#swagger-and-api-versioning)
* [Microsoft Extensions](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/.NET-Core-WebAPI#microsoft-extensions)
* [Feature Flags](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/.NET-Core-WebAPI#feature-flags)
* [Logging](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/.NET-Core-WebAPI#logging)
* [Data Annotations](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/.NET-Core-WebAPI#data-annotations)
* [Authentication](#authentication)
* [Authorization](#authorization)
### [Entity Framework Core](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Entity-Framework-Core)
* [Add Migration](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Entity-Framework-Core#add-migration)
* [Update Database](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Entity-Framework-Core#update-database)
### [Environment Configurations](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Environment-Configurations)
### [DevOps](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/DevOps)
* [Running the Application Locally](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/DevOps#running-the-application-locally)
* [Running the Tests Locally](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/DevOps#running-the-tests-locally)
* [Continuous Integration & Continuous Deployment](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/DevOps#continuous-integration-continuous-deployment)
### [Docker](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Docker)
* [SQL Server](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Docker#sql-server)
### [Related Content and Projects](https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Related-Content-and-Projects)

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://paulovich.net"><img src="https://avatars3.githubusercontent.com/u/7133698?v=4" width="100px;" alt=""/><br /><sub><b>Ivan Paulovich</b></sub></a><br /><a href="#design-ivanpaulovich" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ivanpaulovich" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ivanpaulovich" title="Code">💻</a></td>
    <td align="center"><a href="https://spelos.net/"><img src="https://avatars3.githubusercontent.com/u/21304428?v=4" width="100px;" alt=""/><br /><sub><b>Petr Sedláček</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=petrspelos" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=petrspelos" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/luizgustavogp"><img src="https://avatars2.githubusercontent.com/u/5147169?v=4" width="100px;" alt=""/><br /><sub><b>Gus</b></sub></a><br /><a href="#design-luizgustavogp" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=luizgustavogp" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/arulconsultant"><img src="https://avatars0.githubusercontent.com/u/47856951?v=4" width="100px;" alt=""/><br /><sub><b>arulconsultant</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=arulconsultant" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/guilhermeps"><img src="https://avatars1.githubusercontent.com/u/38736244?v=4" width="100px;" alt=""/><br /><sub><b>Guilherme Silva</b></sub></a><br /><a href="#design-guilhermeps" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=guilhermeps" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=guilhermeps" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/ostorc"><img src="https://avatars1.githubusercontent.com/u/13519594?v=4" width="100px;" alt=""/><br /><sub><b>Ondřej Štorc</b></sub></a><br /><a href="#design-ostorc" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=ostorc" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/MarlonMiranda"><img src="https://avatars3.githubusercontent.com/u/12774904?v=4" width="100px;" alt=""/><br /><sub><b>Marlon Miranda da Silva</b></sub></a><br /><a href="#design-MarlonMiranda" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=MarlonMiranda" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/NicoCG"><img src="https://avatars1.githubusercontent.com/u/33652180?v=4" width="100px;" alt=""/><br /><sub><b>NicoCG</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=NicoCG" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://stackoverflow.com/users/2072198/fals"><img src="https://avatars2.githubusercontent.com/u/3750960?v=4" width="100px;" alt=""/><br /><sub><b>Filipe Augusto Lima de Souza</b></sub></a><br /><a href="#design-fals" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=fals" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=fals" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/sshaw-sml"><img src="https://avatars3.githubusercontent.com/u/33876744?v=4" width="100px;" alt=""/><br /><sub><b>sshaw-sml</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sshaw-sml" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sshaw-sml" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/matheusneder"><img src="https://avatars1.githubusercontent.com/u/6011646?v=4" width="100px;" alt=""/><br /><sub><b>Matheus Neder</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=matheusneder" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/matiienkodimitri"><img src="https://avatars2.githubusercontent.com/u/53822759?v=4" width="100px;" alt=""/><br /><sub><b>димитрий матиенко</b></sub></a><br /><a href="#design-matiienkodimitri" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=matiienkodimitri" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/morphlogic"><img src="https://avatars1.githubusercontent.com/u/29184473?v=4" width="100px;" alt=""/><br /><sub><b>morphlogic</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=morphlogic" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=morphlogic" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/felpasl"><img src="https://avatars3.githubusercontent.com/u/5658895?v=4" width="100px;" alt=""/><br /><sub><b>Felipe Lambert</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=felpasl" title="Tests">⚠️</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=felpasl" title="Code">💻</a></td>
    <td align="center"><a href="https://matray.website"><img src="https://avatars2.githubusercontent.com/u/9035444?v=4" width="100px;" alt=""/><br /><sub><b>Philippe Matray</b></sub></a><br /><a href="#design-phmatray" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=phmatray" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/leandrofagundes"><img src="https://avatars1.githubusercontent.com/u/10363927?v=4" width="100px;" alt=""/><br /><sub><b>Leandro Fagundes</b></sub></a><br /><a href="#question-leandrofagundes" title="Answering Questions">💬</a></td>
    <td align="center"><a href="https://github.com/bommen"><img src="https://avatars2.githubusercontent.com/u/52955252?v=4" width="100px;" alt=""/><br /><sub><b>Bart van Ommen</b></sub></a><br /><a href="#ideas-bommen" title="Ideas, Planning, & Feedback">🤔</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=bommen" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/qpippop"><img src="https://avatars0.githubusercontent.com/u/57645455?v=4" width="100px;" alt=""/><br /><sub><b>qpippop</b></sub></a><br /><a href="#ideas-qpippop" title="Ideas, Planning, & Feedback">🤔</a></td>
    <td align="center"><a href="https://www.linkedin.com/in/cesinhaugusto/"><img src="https://avatars1.githubusercontent.com/u/25554544?v=4" width="100px;" alt=""/><br /><sub><b>Cesar Pereira</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=cesinhaugusto" title="Code">💻</a></td>
    <td align="center"><a href="http://www.edvaldofarias.com.br"><img src="https://avatars2.githubusercontent.com/u/40303187?v=4" width="100px;" alt=""/><br /><sub><b>Edvaldo Farias</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=edvaldofarias" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://codepen.io/sergiobroccardi/posts/published/"><img src="https://avatars1.githubusercontent.com/u/25184212?v=4" width="100px;" alt=""/><br /><sub><b>Sergio Broccardi</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=sbroccardi" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/cuno92"><img src="https://avatars0.githubusercontent.com/u/58431215?v=4" width="100px;" alt=""/><br /><sub><b>cuno92</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=cuno92" title="Code">💻</a></td>
    <td align="center"><a href="http://vmamore.com.br"><img src="https://avatars0.githubusercontent.com/u/26505439?v=4" width="100px;" alt=""/><br /><sub><b>Vinícius Mamoré</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=vmamore" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/dyavolick"><img src="https://avatars1.githubusercontent.com/u/3098528?v=4" width="100px;" alt=""/><br /><sub><b>dyavolick</b></sub></a><br /><a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=dyavolick" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/felipetofoli"><img src="https://avatars0.githubusercontent.com/u/1364311?v=4" width="100px;" alt=""/><br /><sub><b>felipetofoli</b></sub></a><br /><a href="#design-felipetofoli" title="Design">🎨</a> <a href="https://github.com/ivanpaulovich/clean-architecture-manga/commits?author=felipetofoli" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!

> Hit the `FORK` button and show Clean Architecture on your profile. <img src="https://emojis.slackmojis.com/emojis/images/1469223471/679/charmander_dancing.gif?1469223471" width="32" height="32" />
