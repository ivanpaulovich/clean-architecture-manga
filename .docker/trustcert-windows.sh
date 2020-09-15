#!/bin/bash
# https://gist.github.com/epcim/03f66dfa85ad56604c7b8e6df79614e0
dotnet dev-certs https -ep https/localhost.pfx -p MyCertificatePassword
dotnet dev-certs https --trust