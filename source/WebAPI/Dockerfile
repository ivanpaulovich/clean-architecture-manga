FROM microsoft/dotnet:2.0-sdk

ENV ASPNETCORE_URLS="http://*:80"

EXPOSE 80
WORKDIR /app
COPY . .

WORKDIR /app/Manga.UI

ENTRYPOINT ["dotnet", "run"]