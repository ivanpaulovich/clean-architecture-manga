#!/bin/bash
echo "1. Generating self-signed certificate used by IdentityServer and Accounts applications..."
dotnet dev-certs https -ep ~/.aspnet/https/aspnetapp.pfx -p MyCertificatePassword
echo "2. Trusting self-signed certificate.."
dotnet dev-certs https --trust
echo "3. Building Docker images in silent mode. This may take a while..."
docker-compose build --quiet
echo "4. Starting up SQL Server in Docker..."
docker-compose up -d sql1
echo "5. Installing Entity Framework Tool to migrate databases."
dotnet tool update --global dotnet-ef --version 3.1.7
echo "6. Generating accounts schema in DB..."
dotnet ef database update --project ../accounts-api/src/Infrastructure --startup-project ../accounts-api/src/WebApi
echo "7. Starting up Identity Server and Accounts applications."
docker-compose up -d
echo -e "8. Browse to $(tput setaf 1)https://localhost:5010$(tput sgr0)\n\nUse the following credentials to login in Identity Server:\n\n\tUsername:\t$(tput setaf 1)alice$(tput sgr0)\n\tPassword:\t$(tput setaf 1)alice$(tput sgr0)"
echo -e "\nTrust the NPM HTTPS certificate manually see: \n\nhttps://stackoverflow.com/questions/47482264/cannot-accept-self-signed-certificate-in-safari-11-to-access-vagrant-homestead"
