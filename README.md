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
BankingSystemAPI/
│
├── Controllers/        → HTTP request handling
├── Services/           → Business logic
├── Repositories/       → Database queries
├── Models/             → Account, Transaction entities
├── DTOs/               → Request/response shapes
├── Exceptions/         → Custom exception classes
└── Data/               → DB connection and raw queries

---

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/accounts/create` | Create a new account |
| POST | `/api/accounts/deposit` | Deposit money |
| POST | `/api/accounts/withdraw` | Withdraw money |
| POST | `/api/accounts/transfer` | Transfer between accounts |

---

## Getting Started

**1. Clone the repo**
```bash
git clone https://github.com/your-username/banking-system-api.git
```

**2. Open in Visual Studio**

Open the `.sln` file and restore NuGet packages.

**3. Set up the database**

Update the connection string in `appsettings.json` to point to your SQL Server
instance.

**4. Run**

Press `F5` in Visual Studio or use the CLI:
```bash
dotnet run
```

Then open Postman and hit the endpoints listed above.

---

## What's Next

A few things I plan to add:

- [ ] JWT authentication and protected routes
- [ ] Migrate from ADO.NET to Entity Framework Core
- [ ] Structured logging
- [ ] Frontend client in React or Angular
- [ ] Cloud deployment on Azure or AWS

---

## About

Built by **Sanan Malik** — CS student focusing on backend development.
This project is for learning purposes.
