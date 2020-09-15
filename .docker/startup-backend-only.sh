#!/bin/bash
echo "1. Building Docker images in silent mode. This may take few minutes..."
echo -e "\n\n\tEnsure Docker is up and running.\n\n"
docker-compose build --quiet
echo "2. Starting up SQL Server in Docker..."
docker-compose up -d sql1
echo "3. Updating DB using Entity Framework Tool..."
./init-db
echo -e "4. Starting up applications:"
echo -e "\tIdentity Server."
echo -e "\tAccounts."
docker-compose up -d identity-server
docker-compose up -d accounts-api