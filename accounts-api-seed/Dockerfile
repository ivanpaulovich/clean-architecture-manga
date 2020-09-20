FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
RUN dotnet tool update --global dotnet-ef --version 3.1.8
WORKDIR /src
COPY . .
RUN dotnet restore "src/WebApi/WebApi.csproj"
RUN dotnet build "src/WebApi/WebApi.csproj" --no-restore
