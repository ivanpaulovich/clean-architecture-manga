#!/bin/bash
dotnet restore
dotnet test **/UnitTests/*.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov
dotnet test **/IntegrationTests/*.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov
dotnet test **/AcceptanceTests/*.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov
#./tools/reportgenerator "-reports:./TestResults/Coverage/coverage.cobertura.xml" "-targetdir:./TestResults/Coverage/Reports" -reporttypes:Html;HtmlSummary;HtmlInline;HtmlInline_AzurePipelines;HtmlInline_AzurePipelines_Dark