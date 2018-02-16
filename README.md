# Manga: Clean Architecture
A solution with Use Cases as first class.

![Flow of Control: Customer Registration](https://github.com/ivanpaulovich/manga/blob/master/Flow-Of-Control.png)

# Main Architectural Concepts
On of the goals of the clean architecture is to encapsulate the business logic in an clean way, with no dependencies to details like (UI, Database version or Frameworks). And by building a software that looks like your Business Domain at the first look of the source code. The architecture must put Use Cases as first class modules.

If you are interested check out [The Clean Architecture post by Uncle Bob](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) or his latest book [Clean Architecture](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164/ref=sr_1_1?ie=UTF8&qid=1518796865&sr=8-1&keywords=clean+architecture).

By following Uncle Bob material, we developed this project to have this Dimensions (Fitness Functions will came later):

* Independent of Frameworks.
* Testable. 
* Independent of UI. 
* Independent of Database. 
* Independent of any external agency.

![Clean Architecture by Uncle Bob](https://github.com/ivanpaulovich/manga/blob/master/CleanArchitecture-Uncle-Bob.jpg)

## DDD
The use cases of this project is to manage an account balance with deposit and credits and its concepts is enforced by the Domain and Application. Also we use the Eric Evans terms like Entities, Value Object, Aggregates, Aggregate Root and etc. And everything is on a single Bounded Context.

## TDD
From the beginning of the project we developed Unit Tests and that helped us to enforce the business rules and to create an application that prevents bugs intead of finding them. We also have Use Case tests and Mapping Tests and a more sophistecated Integration Tests. 

## SOLID
The SOLID principles are all over the the solution. Knoleadge of SOLID is not a prerequisite to understand and run the solution but it is highly recommended.

## Entity-Boundary-Interactor (EBI)
The goal of EBI architecture is to produce a software implementation agnostic to technology, framework and to have a focus on the use cases and input/output. 

## Microservice
Even though the definition of microservice may be different for different professionals. We have tried to value some aspects like Continous Delivery, modelled around Business Domain and Independent Deployment.

## Logging
Loggin is a detail. We plugged Serilog and configured it to redirect every log message to files.

## Docker
Docker is a detail of this architecture. And it was implemented to help us make a faster and reliable deployment. You could pull the [Manga latest image any time.](https://hub.docker.com/r/ivanpaulovich/manga/)

## Mongo DB
Mongo DB is a detail. At infrastructure layer we implemented the ICustomerWriteOnlyRepository to update the Mongo database.

## .NET Core 2.0
.NET Core is a detail. Almost everything in this code base could be ported to older versions.

# Requirements
* [Visual Studio 2017 with Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/)

# Environment setup

* Run the `./prerequisites.sh` script to download the MongoDB image and run as a Docker container. 
Please wait until the ~400mb download to be complete.

```
$ ./prerequisites.sh
Pulling mongodb (mongo:latest)...
latest: Pulling from library/mongo
Digest: sha256:2c55bcc870c269771aeade05fc3dd3657800540e0a48755876a1dc70db1e76d9
Status: Downloaded newer image for mongo:latest
Creating setup_mongodb_1 ...
Creating setup_mongodb_1
Creating setup_mongodb_1 ... done
```
* Check Mongo image with the the following commands:

```
$ docker images
REPOSITORY          TAG                 IMAGE ID            CREATED             SIZE
mongo               latest              d22888af0ce0        17 hours ago        361MB
$ docker ps
CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS              PORTS                                            NAMES
ba28cf144478        mongo               "docker-entrypoint..."   2 days ago          Up 2 days           0.0.0.0:27017->27017/tcp                         setup_mongodb_1
```

If everything goes well MongoDB will be running with the `mongodb://10.0.75.1:27017` connection string.

# Running the latest Docker Build ![Authorization](https://dockerbuildbadges.quelltext.eu/status.svg?organization=ivanpaulovich&repository=manga)

If you like to run a Docker container for this project use the latest image:

```
$ docker run -p 8000:80 -d \
		-e modules__2__properties__ConnectionString=mongodb://10.0.75.1:27017 \
		--name manga-backend \
		ivanpaulovich/manga:latest
```
Then navigate to http://localhost:8000/swagger and play with de API.

# We are live on Azure

![Live on Azure](https://github.com/ivanpaulovich/manga/blob/master/Swagger.png)

You can play with the latest build by navigating to [the Swagger client](http://grape.westus2.cloudapp.azure.com:8800/swagger "Manga Swagger").

This source code and website should be used only for learning purposes and **all data will be erased weekly**.
