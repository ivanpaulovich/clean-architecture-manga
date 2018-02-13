#!/bin/bash
DOCKERPULL=`docker pull ivanpaulovich/manga:latest`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
        echo "Updating"
        docker stop manga-backend
        docker rm manga-backend
        docker run -p 8000:80 \
                -e modules__2__properties__ConnectionString=mongodb://172.17.0.1:27017 \
                -d \
                --name manga-backend \
                ivanpaulovich/manga:latest
else
        echo "Image is already updated"
fi