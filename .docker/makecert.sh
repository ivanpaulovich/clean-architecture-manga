#!/bin/bash
openssl req -x509 -newkey rsa:2048 -keyout localhost.key -out localhost.crt -days 365 -nodes -config ./ssl-selfsigned.cnf
openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt -name "Localhost selfsigned certificate" -password pass:MyCertificatePassword
rm ~/.aspnet/https/localhost.key
rm ~/.aspnet/https/localhost.crt
rm ~/.aspnet/https/localhost.pfx
rm ../wallet-spa/localhost.key
rm ../wallet-spa/localhost.crt
rm ../nginx/localhost.key
rm ../nginx/localhost.crt
cp localhost.key ~/.aspnet/https/localhost.key
cp localhost.crt ~/.aspnet/https/localhost.crt
cp localhost.pfx ~/.aspnet/https/localhost.pfx
cp localhost.key ../wallet-spa/localhost.key
cp localhost.crt ../wallet-spa/localhost.crt
cp localhost.key ../nginx/localhost.key
cp localhost.crt ../nginx/localhost.crt