# Manga: Clean Architecture
A solution with Use Cases as first class.

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

# Running the latest Docker Build ![Authorization](https://dockerbuildbadges.quelltext.eu/status.svg?organization=ivanpaulovich&repository=acerola)

If you like to run a Docker container for this project use the latest image:

```
docker run -p 8000:80 \
		-e modules__2__properties__ConnectionString=mongodb://10.0.75.1:27017 \
		-d \
		--name manga-backend \
		ivanpaulovich/manga:latest
```
Then navigate to http://localhost:8000/swagger and play with de API.
