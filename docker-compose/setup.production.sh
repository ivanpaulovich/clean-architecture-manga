#!/bin/bash

# 1. makecert

openssl req -x509 -newkey rsa:2048 -keyout ./https/localhost.key -out ./https/localhost.crt -days 365 -subj "/CN=wallet.local/O=wallet.local/C=US" -config ./ssl-selfsigned.cnf -passout pass:MyCertificatePassword
openssl pkcs12 -export -out ./https/localhost.pfx -inkey ./https/localhost.key -in ./https/localhost.crt -name "Localhost selfsigned certificate" -password pass:MyCertificatePassword -passin pass:MyCertificatePassword
openssl rsa -in ./https/localhost.key -out ./https/localhost.key -passin pass:MyCertificatePassword

# 2. [trustcert](https://gist.github.com/epcim/03f66dfa85ad56604c7b8e6df79614e0)

sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain ./https/localhost.crt

# 3. hostadd

cat << EOF >> /etc/hosts
# To allow the same website for Wallet SPA/IdentityServer and AccountsAPI
127.0.0.1 wallet.local
# End of section
EOF
exit

# 4. build

docker-compose build --no-cache

# 5. run

docker-compose -f docker-compose.yml -f docker-compose.production.yml up -d