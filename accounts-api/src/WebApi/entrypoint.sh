#!/bin/sh
cp /https/localhost.crt /usr/local/share/ca-certificates/localhost.crt
update-ca-certificates
dotnet WebApi.dll
