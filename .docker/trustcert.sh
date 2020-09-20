#!/bin/bash
# https://gist.github.com/epcim/03f66dfa85ad56604c7b8e6df79614e0
sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain https/localhost.crt