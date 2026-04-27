# Banking System API — ASP.NET Core

A backend banking system built with C# and ASP.NET Core Web API that simulates
real-world banking operations. This project was built to practice layered
architecture and OOP principles in a realistic context.

---

## What This Project Does

This API handles the core operations you'd expect from a banking backend:

- Open new bank accounts
- Deposit and withdraw money
- Transfer funds between accounts
- Track transaction history
- Handle invalid operations gracefully with proper error responses

---

## Why I Built It This Way

I didn't just want something that works — I wanted it structured like a real
production system. So the project follows a strict layered architecture:

- **Controllers** handle incoming HTTP requests and route them
- **Services** contain all the business logic
- **Repositories** talk to the database, keeping data access isolated
- **DTOs** separate what the API exposes from internal models
- **Custom Exceptions** give meaningful error messages instead of generic crashes

This separation makes the codebase easier to maintain, test, and extend.

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
