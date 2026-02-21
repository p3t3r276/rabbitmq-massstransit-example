# Order Processing API (.NET 9 + MassTransit)

This is a microservice-style Web API that demonstrates asynchronous order processing using RabbitMQ.

## Prerequisites
- .NET 9 SDK
- RabbitMQ running locally (Default port 5672)
  - *Quick Start:* `docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management`

## Running the App
1. Navigate to `OrderApi/`
2. Run `dotnet run`
