#!/bin/bash
sudo docker stop sql1
sudo docker rm sql1
sudo docker pull mcr.microsoft.com/mssql/server:2017-latest
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest
sleep 10
sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<YourStrong!Passw0rd>' -Q 'ALTER LOGIN SA WITH PASSWORD="<YourNewStrong!Passw0rd>"'
dotnet tool install --global dotnet-ef
dotnet ef database update --project src/Infrastructure --startup-project src/Infrastructure

# query

# sudo docker exec -it sql1 "bash"
# /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<YourNewStrong!Passw0rd>'
# SELECT Name from sys.Databases
# GO
# USE MangaDB01
# GO
# SELECT * FROM Account
# GO
