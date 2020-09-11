#!/bin/bash
openssl req -x509 -newkey rsa:4096 -keyout localhost.key -out localhost.crt -days 3650 -nodes -subj "/CN=localhost" -config ssl-selfsigned.cnf
openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt -name "Localhost selfsigned certificate" -password pass:MyCertificatePassword
cp localhost.key ~/.aspnet/https/localhost.key
cp localhost.crt ~/.aspnet/https/localhost.crt
cp localhost.pfx ~/.aspnet/https/localhost.pfx

cp localhost.key ../wallet-spa/localhost.key
cp localhost.crt ../wallet-spa/localhost.crt

cp localhost.key ../nginx/localhost.key
cp localhost.crt ../nginx/localhost.crt