# Microservice with RabbitMQ

## Objectives
The objective of this microservice is to send a message to a queue in RabbitMQ and to be a consumer at the same time.
The configuration of RabbitMQ instance, login and queue name are located in `appsettings.json` inside the console app folder `(src/Microservice.MQ.Client/appsettings.json)`:

```json
{
  "RabbitMq": {
    "Hostname": "localhost",
    "QueueSendName": "HelloWorldQueue",
    "QueueConsumeName": "HelloWorldQueue",
    "UserName": "guest",
    "Password": "guest"
  }
}
```

**Hostname**: The address of RabbitMQ instance

**QueueSendName**: : Name of the queue to send the messages

**QueueConsumeName**: Name of the queue to receive the messages

**UserName**: Username of RabbitMQ instance

**Password**: Password of RabbitMQ instance

## Prerequisites
- [.NET Core 3.1](https://dotnet.microsoft.com/download)
- [RabbitMQ](https://www.rabbitmq.com/) (Can be used with Docker)
- [Docker](https://www.docker.com/get-started) (Optional)

## Languagues used
C# (.NET Core 3.1)

# How to Use
Edit the json settings to configure RabbitMQ host, and build the main console located in `src\Microservice.MQ.Client`.
The console will start sending messages to `QueueSendName` and receive from `QueueConsumeName`.

# How to run with dotnet
After cloning the project, go to `src\Microservice.MQ.Client` and use the following command through a terminal:
```
dotnet run Microservice.MQ.Client.csproj
```

# Project Structure
The project tree consists of the following projects:

```bash
└───src
    ├───Microservice.MQ.Client
    │   └───Properties
    ├───Microservice.MQ.CrossCut
    ├───Microservice.MQ.Service
    │   └───Services
    └───Microservice.MQ.Service.Domain
        ├───Interfaces
        ├───Models
        └───RabbitMQ
```

**Microservice.MQ.Service**

Used for business rules and service applications. Contains the service classes.

**Microservice.MQ.Client**

The main entry of application. Contains the main console project for use.

**Authorizer.CrossCut**

A CrossCut layer for applying DI (Dependency Injection) for interfaces.

**Authorizer.Domain**

The main project for model classes and interfaces.
