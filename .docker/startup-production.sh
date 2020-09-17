#!/bin/bash
if [ `ls -1 https/localhost.* 2>/dev/null | wc -l ` -gt 0 ];
then
    echo "0. Using certificates from $(tput setaf 3)https$(tput sgr0) folder."
else
    echo "ERROR: Failed to find certificates. Check the specific makecert script for your OS."
    exit 1
fi
echo "1. Building Docker images. This may take few minutes..."
echo -e "\n\n\tEnsure Docker is up and running.\n\n"
docker-compose build
echo "2. Starting up applications. This may take few minutes..."
docker-compose -f docker-compose.yml -f docker-compose.production.yml up -d
echo -e "3. Manually add the entry $(tput setaf 3)127.0.0.1 wallet.local$(tput sgr0) to the hosts file."
echo -e "\tBrowse to $(tput setaf 3)https://wallet.local/$(tput sgr0)\n\nUse the following credentials to login into Identity Server:\n\n\tUsername:\t$(tput setaf 3)alice$(tput sgr0)\n\tPassword:\t$(tput setaf 3)alice$(tput sgr0)"
echo -e "\tRun $(tput setaf 3)docker ps$(tput sgr0) to check if all containers are up. The frontend SPA could take several minutes to get ready."

