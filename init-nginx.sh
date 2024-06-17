#!/bin/bash

# Directory where the certificates will be stored
SSL_CERT_DIR="/etc/nginx/certs"

# Certificate and key paths
SSL_CERT="$SSL_CERT_DIR/localhost.crt"
SSL_KEY="$SSL_CERT_DIR/localhost.key"

# Check if the SSL certificate and key files exist
if [ ! -f "$SSL_CERT" ] || [ ! -f "$SSL_KEY" ]; then
    echo "SSL certificate not found. Generating a new one..."
    mkdir -p $SSL_CERT_DIR

    # Generate a self-signed SSL certificate
    openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
        -keyout $SSL_KEY -out $SSL_CERT \
        -subj "/CN=localhost"
else
    echo "SSL certificate found. Using existing certificate."
fi

# Execute the main command (e.g., starting NGINX)
exec "$@"