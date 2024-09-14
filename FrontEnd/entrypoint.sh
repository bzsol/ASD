#!/bin/sh

# Replace placeholder in config.json with the API_URL environment variable
if [ -n "$API_URL" ]; then
  echo "{
    \"API_URL\": \"$API_URL\"
  }" > /usr/local/apache2/htdocs/config.json
else
  echo "API_URL environment variable is not set. Using default config.json."
fi

# Start Apache in the foreground
exec httpd-foreground
