#!/bin/bash
dotnet tool update --global dotnet-ef --version 3.1.8
dotnet ef database update --project ../accounts-api/src/Infrastructure --startup-project ../accounts-api/src/WebApi