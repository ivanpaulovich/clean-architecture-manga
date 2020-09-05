#!/bin/bash
echo "1. Generating self-signed certificate used for HTTPS..."
dotnet dev-certs https -ep ~/.aspnet/https/aspnetapp.pfx -p MyCertificatePassword
echo -e "2. Trusting certificate using $(tput setaf 3)dotnet dev-certs https --trust$(tput sgr0)."
echo -e "\n\n\tYou many need admin rights to continue.\n\n"
dotnet dev-certs https --trust
echo "3. Converting .pfx file into .crt and .key then moving to wallet-spa folder"
echo -e "\n\n\tYou many need to install openssl.\n\n"
openssl pkcs12 -in ~/.aspnet/https/aspnetapp.pfx -out ~/.aspnet/https/cert.pem -nodes -passin pass:MyCertificatePassword
openssl pkey -in ~/.aspnet/https/cert.pem -out ../wallet-spa/cert.key
openssl x509 -in ~/.aspnet/https/cert.pem -out ../wallet-spa/cert.crt
# The certificate aspnetapp.pfx and the combo cert.key/cert.crt are equivalent here.
echo "4. Building Docker images in silent mode. This may take few minutes..."
echo -e "\n\n\tYou many need to startup Docker.\n\n"
docker-compose build --quiet
echo "5. Starting up SQL Server in Docker..."
docker-compose up -d sql1
echo "6. Installing Entity Framework Tool to migrate databases."
dotnet tool update --global dotnet-ef --version 3.1.7
echo "7. Generating accounts schema in DB..."
dotnet ef database update --project ../accounts-api/src/Infrastructure --startup-project ../accounts-api/src/WebApi
echo "8. Starting up Identity Server and Accounts applications."
docker-compose up -d
echo -e "9. Browse to $(tput setaf 3)https://localhost:5010$(tput sgr0)\n\nUse the following credentials to login into Identity Server:\n\n\tUsername:\t$(tput setaf 3)alice$(tput sgr0)\n\tPassword:\t$(tput setaf 3)alice$(tput sgr0)"
