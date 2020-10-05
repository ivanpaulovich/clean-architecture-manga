#!/bin/bash
cat << EOF >> /etc/hosts
# To allow the same website for Wallet SPA/IdentityServer and AccountsAPI
127.0.0.1 wallet.local
# End of section
EOF
exit