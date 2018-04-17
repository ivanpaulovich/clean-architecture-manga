#!/bin/bash
dotnet build "MyProject.Infrastructure/MyProject.Infrastructure.csproj"
#if( UI-Webapi )
dotnet build "MyProject.WebApi/MyProject.WebApi.csproj"
#endif