# Banking System API - ASP.NET Core

A back-end banking system developed in C# and ASP.real-world banking operations.
real-world banking operations. It was developed to learn about
design and OOP techniques in a real world scenario.

---

## What This Project Does

This API provides the basic functions of a bank:

- Open new bank accounts
- Deposit and withdraw money
- Transfer funds between accounts
- Track transaction history
- Gracefully handle invalid operations with error messages

---

## Why I Built It This Way

I wanted more than just a solution - I wanted a solution that looked like a production system
production system. So I've organised the project in a layered way:

- Controllers deal with the HTTP requests
- Services are responsible for the business logic
- Repositories access the database, separating data access
- DTOs keep the API from the models
- Custom Exceptions for helpful error messages, rather than crashes

This allows better maintainability, testability and extensibility.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| Framework | ASP.NET Core Web API |
| Database Access | ADO.NET |
| Database | SQL Server |
| API Testing | Postman |

---

## Project Structure
