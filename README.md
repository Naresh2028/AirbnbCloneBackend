# Airbnb Clone

Full-stack property management application built with **ASP.NET Core Web API** and **Angular**.

## Features

- User signup and login
- JWT authentication
- Property CRUD


## Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / Azure SQL
- JWT Authentication

### Frontend
- Angular
- TypeScript
- Reactive Forms
- Template-driven Forms
- RxJS
- HttpClient
- HTTP Interceptor
- Bootstrap

## Project Structure

```text
AirbnbCloneBackend/
├── AirbnbCloneBackend.Api/
│   ├── Controllers/
│   ├── wwwroot/uploads/properties/
│   └── Program.cs
├── AirbnbCloneBackend.Application/
├── AirbnbCloneBackend.Infrastructure/
│   ├── Repositories/
│   └── Migrations/
└── AirbnbCloneBackend.sln

```

## API Endpoints

### Authentication

```text
POST /api/Auth/signup
POST /api/Auth/login
```

### Properties

```text
GET    /api/Property
GET    /api/Property/{id}
POST   /api/Property
PUT    /api/Property/{id}/update
PATCH  /api/Property
```

## Image Upload

Property creation uses `multipart/form-data`.

Uploaded images are stored under:

```text
wwwroot/uploads/properties/
```

## Backend Setup

### Prerequisites

- .NET SDK 10
- SQL Server or Azure SQL

### 1. Configure the database

Add your connection string locally:

```json
{
  "ConnectionStrings": {
    "AppDbConnection": "YOUR_CONNECTION_STRING"
  }
}
```

### 2. Apply migrations

```bash
dotnet ef database update --project AirbnbCloneBackend.Infrastructure --startup-project AirbnbCloneBackend.Api
```

### 3. Run the API

```bash
dotnet run --project AirbnbCloneBackend.Api
```

