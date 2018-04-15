![Manga](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/manga-icon.png) Manga: Clean Architecture
=========
[![Manga latest Docker build](https://dockerbuildbadges.quelltext.eu/status.svg?organization=ivanpaulovich&repository=manga)](https://hub.docker.com/r/ivanpaulovich/manga/) [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/ivanpaulovich/)

Manga is a Service Template for helping you to build evolvable, adaptable and maintainable applications. It follows the principles from the [Clean Architecture book](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164) and has a Domain built on Domain-Driven Design. It is easy for you to start your new microservice based on its guidelines and patterns.

## Compiling from source

To run Manga from source, clone this repository to your machine, compile and test it:

```sh
git clone https://github.com/ivanpaulovich/manga.git
cd manga/source/WebAPI/Manga.WebApi
dotnet run
```

## The Clean Architecture

The implementation result of the Clean Architecture is a software that encapsulate Business Rules in Use Cases and the Enterprise Rules in Entities. Also the Use Cases are independent from details like User Interface, Data Access, Web Server or any external agency. 

![Clean Architecture by Uncle Bob](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/CleanArchitecture-Uncle-Bob.jpg)
> The Clean Architecture Diagram by [Uncle Bob](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html).

| Concept | Description |
| --- | --- |
| DDD | The Use Cases of the Account Balance are the Ubiquitious Language designed in the Domain and Application layers, we use the Eric Evans terms like Entities, Value Object, Aggregates Root and Bounded Context. |
| TDD | From the beginning of the project we developed Unit Tests that helped us to enforce the business rules and to create an application that prevents bugs intead of finding them. We also have more sophisticated tests like Use Case Tests, Mapping Tests and Integration Tests. |
| SOLID | The SOLID principles are all over the the solution. The knowledge of SOLID is not a prerequisite but it is highly recommended. |
| Entity-Boundary-Interactor (EBI) | The goal of EBI architecture is to produce a software implementation agnostic to technology, framework, or database. The result is focus on  use cases and input/output. |
| Microservice | We designed the software around the Business Domain, having Continous Delivery and Independent Deployment. |
| Logging | Logging is a detail. We plugged Serilog and configured it to redirect every log message to the file system. |
| Docker | Docker is a detail. It was implemented to help us make a faster and reliable deployment. |
| MongoDB | MongoDB is a detail. You could create new Data Access implementation and setup it with Autofac. |
| .NET Core 2.0 | .NET Core is a detail. Almost everything in this code base could be ported to other versions. |

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
