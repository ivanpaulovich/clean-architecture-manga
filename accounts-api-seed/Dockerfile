FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

RUN dotnet tool update --global dotnet-ef --version 5.0.1
WORKDIR /src
COPY . .
RUN dotnet restore "src/WebApi/WebApi.csproj"
RUN dotnet build "src/WebApi/WebApi.csproj" --no-restore
