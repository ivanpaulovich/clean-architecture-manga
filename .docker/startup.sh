#!/bin/bash
echo "1. Building Docker images in silent mode. This may take few minutes..."
echo -e "\n\n\tEnsure Docker is up and running.\n\n"
docker-compose build --quiet
echo "2. Starting up SQL Server in Docker..."
docker-compose up -d sql1
echo "3. Installing Entity Framework Tool to migrate databases."
dotnet tool update --global dotnet-ef --version 3.1.7
echo "4. Generating accounts schema in DB..."
dotnet ef database update --project ../accounts-api/src/Infrastructure --startup-project ../accounts-api/src/WebApi
echo "5. Starting up Identity Server and Accounts applications."
docker-compose up -d
echo -e "6. Browse to $(tput setaf 3)https://wallet.local/$(tput sgr0)\n\nUse the following credentials to login into Identity Server:\n\n\tUsername:\t$(tput setaf 3)alice$(tput sgr0)\n\tPassword:\t$(tput setaf 3)alice$(tput sgr0)"
