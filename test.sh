#!/bin/bash

API_URL="http://localhost:5000/orders"

echo "Sending Test Order..."
curl -X POST $API_URL \
     -H "Content-Type: application/json" \
     -d '{"customerName": "John Doe", "amount": 99.99}' \
     -i

echo -e "\n\nCheck the console logs of the API to see the Consumer processing the message."
