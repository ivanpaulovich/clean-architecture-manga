#!/bin/bash
openssl req -x509 -newkey rsa:2048 -keyout https/localhost.key -out https/localhost.crt -days 365 -nodes -config ssl-selfsigned.cnf
openssl pkcs12 -export -out https/localhost.pfx -inkey https/localhost.key -in https/localhost.crt -name "Localhost selfsigned certificate" -password pass:MyCertificatePassword