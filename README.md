![Manga](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/manga-icon.png) Manga: Clean Architecture
=========
[![Manga latest Docker build](https://dockerbuildbadges.quelltext.eu/status.svg?organization=ivanpaulovich&repository=manga)](https://hub.docker.com/r/ivanpaulovich/manga/)

Manga is a Service Template for helping you to build evolvable, adaptable and maintainable applications. It follows the principles from [Clean Architecture book](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164) and has a Domain built on Domain-Driven Design. It is easy for you to start your new microservice based on his guidelines and patterns.

## Compiling from source

To run Manga from source, clone this repository to your machine, compile and test it:

```sh
git clone https://github.com/ivanpaulovich/manga.git
cd manga/source/WebAPI/Manga.UI
dotnet run
```

## The Clean Architecture

The implementation result of the Clean Architecture is a software that encapsulate Business Rules in Use Cases and the Enterprise Rules in Entities. Also the Use Cases are independent from details like User Interface, Data Access, Web Server or any external agency. 

![Clean Architecture by Uncle Bob](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/CleanArchitecture-Uncle-Bob.jpg)
> The Clean Architecture Diagram by [Uncle Bob](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html).

| Concept | Description |
| --- | --- |
| DDD | The use cases of this project is to manage an account balance with deposit and credits and its concepts is enforced by the Domain and Application. Also we use the Eric Evans terms like Entities, Value Object, Aggregates, Aggregate Root and etc. And everything is on a single Bounded Context. |
| TDD | From the beginning of the project we developed Unit Tests and that helped us to enforce the business rules and to create an application that prevents bugs intead of finding them. We also have Use Case tests and Mapping Tests and a more sophistecated Integration Tests.  |
| SOLID | The SOLID principles are all over the the solution. Knowledge of SOLID is not a prerequisite to understand and run the solution but it is highly recommended. |
| Entity-Boundary-Interactor (EBI) | The goal of EBI architecture is to produce a software implementation agnostic to technology, framework and to have a focus on the use cases and input/output. |
| Microservice | Even though the definition of microservice may be different for different professionals. We have tried to value some aspects like Continous Delivery, modelled around Business Domain and Independent Deployment. |
| Logging | Loggin is a detail. We plugged Serilog and configured it to redirect every log message to files. |
| Docker | Docker is a detail of this architecture. And it was implemented to help us make a faster and reliable deployment. You could pull the latest image |
| MongoDB | MongoDB is a detail. At infrastructure layer we implemented the ICustomerWriteOnlyRepository to update the Mongo database. |
| .NET Core 2.0 | .NET Core is a detail. Almost everything in this code base could be ported to older versions. |

## Flow of Control: The Register Use Case

![Flow of Control: Customer Registration](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/Flow-Of-Control.png)

## Requirements
* [Visual Studio 2017 with Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/)

## Prerequisites Setup

The only one prerequisite to run the Web API is a valid connection string to MongoDB. To help you run it without hard work follow the steps on [prerequisites setup](https://github.com/ivanpaulovich/manga/wiki/Prerequisites-setup) page.

## Running the latest Docker Build

You can run the Docker container of this project with the following command:

```sh
$ docker run -p 8000:80 -d \
	-e modules__2__properties__ConnectionString=mongodb://10.0.75.1:27017 \
	--name manga \
	ivanpaulovich/manga:latest
```
Then navigate to http://localhost:8000/swagger and play with de Swagger.

## Live Demo on Azure

[![Manga Live Demo on Azure](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/Swagger.png)](http://grape.westus2.cloudapp.azure.com:8800/swagger)

You can play with the latest build of [Manga](http://grape.westus2.cloudapp.azure.com:8800/swagger "Manga").
> This source code and website should be used only for learning purposes and **all data will be erased weekly**.
