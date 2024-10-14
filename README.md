# serviceAPI

## Description
Along with the service at https://github.com/larisqueiroz/serviceAPIsender, this is a simple microservice application that processes orders and provides informations.

## Architecture
![architecture.png](%2FScreenshots%2Farchitecture.png)

## ER Diagram
![er.png](%2FScreenshots%2Fer.png)

## Built With
* Docker Compose
* PostgreSQL
* RabbitMQ

## Features
* Reading product types, clients and order details.
* Calculating an order's total value.
* Reading a client's order quantity.
* Reading a client's orders list.

## Getting Started

1. Execute the command bellow:
```
docker-compose up --build
```
to run this project which acts as the consumer. Also, clone and run the same command above for the project at https://github.com/larisqueiroz/serviceAPIsender to run the producer.

2. Access http://localhost:3500 to see the API.

## Tests

Inside serviceAPI\ServiceAPI\ServiceAPI.Tests, run:
```
dotnet test
```

## Contact me
https://www.linkedin.com/in/larissalimaqueiroz/