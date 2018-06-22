![Manga](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/manga-icon.png) Clean Architecture Service Template with TDD/DDD
=========
[![Manga latest Docker build](https://dockerbuildbadges.quelltext.eu/status.svg?organization=ivanpaulovich&repository=manga)](https://hub.docker.com/r/ivanpaulovich/manga/) [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/ivanpaulovich/)

Manga is a Service Template to help you to build evolvable, adaptable and maintainable applications. It follows the Clean Architecture Principles (Robert C. Martin, 2017) and Domain-Driven Design. Tests guided us on the implementation so all the components are testable in isolation.

## Compiling from source

To run Manga from source, clone this repository to your machine, compile and test it:

```sh
git clone https://github.com/ivanpaulovich/clean-architecture-manga.git
cd clean-architecture-manga
./build.sh
```

## The Clean Architecture

The Clean Architecture implementation is a software where the business rules are encapsulated in the use cases and entities. The Application and Domain layers are independent from external details like frameworks, the UI, or data access libraries.

We followed the Dependency Rule that says the source code dependencies can only point inwards, nothing in an inner circle can know anything at all about something in an outer circle.

To ilustrate this principle compare the Clean Architecture Diagram by [Uncle Bob](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) with the source code.

![Clean Architecture by Uncle Bob](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/CleanArchitecture-Uncle-Bob.jpg)

## The Principles and Practices

The code base is implemented around the Use Cases, and to design the solution we followed major principles described next: 

| Concept | Description |
| --- | --- |
| DDD | The Domain-Driven Design helped us on designing effective aggregates. The Customer and Account are aggregates and they keep the state consistent, we also have value-objects for Money and SSN. |
| TDD | We design the software as tests are the first consumer of the application. They show us early how to use the API and what requirements we will implement first. |
| SOLID | The SOLID principles are all over the solution. We had an special effort on Dependency Inversion and Single Responsibility Principle.  |
| Hexagonal Architecture | The Clean Architecture is built on top of Hexagonal Architecture, we still have Ports for Use Cases and Adapters for every external detail. |
| Microservice | This application has and independent business domain, built with continous delivery and independent deployment. |
| Logging | Logging is a detail. We plugged Serilog and configured it to redirect every log message to the file system. |
| Docker | Docker is a detail. The CD builds an image for every commit. |
| MongoDB | MongoDB is a detail. We can change to any other database with few lines of code. |
| .NET Core 2.0 | .NET Core is a detail. The main code is portable to other .NET frameworks. |

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
