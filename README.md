# Unit of Work and Repository Pattern with MediatR in Clean Architecture (using .NET 8)

This project demonstrates the implementation of the **Unit of Work** and **Repository Pattern** with **MediatR** in a **Clean Architecture** approach using **.NET 8**. The architecture is designed to separate concerns and enable easier maintenance and scalability.

## Features

- **Clean Architecture** setup with separation of concerns into layers: API, Application, Domain, and Infrastructure.
- **Unit of Work** and **Repository Pattern** to manage data access and transactions.
- **MediatR** for handling commands, queries, and events with loose coupling.

## Project Structure

- **Api**: Contains controllers that handle HTTP requests.
- **Application**: Contains business logic, commands, queries, and MediatR handlers.
- **Domain**: Defines entities, interfaces, and core business rules.
- **Infrastructure**: Provides implementations for data access and services (e.g., repositories).

## Setup

1. Clone the repository.
2. Install necessary NuGet packages: