# Airbnb Clone

Full-stack property management application built with **ASP.NET Core Web API** and **Angular**.

## Features

- User signup and login
- JWT authentication
- Property creation and image upload
- Property listing
- Search and status filtering
- Server-side pagination
- Property details
- Property editing
- Property status updates
- Angular HTTP interceptor for JWT handling and HTTP errors

## Tech Stack

### Backend
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server / Azure SQL
- JWT Authentication
- Repository and Service pattern
- EF Core Migrations

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

airbnb-clone-frontend/
└── src/
    └── app/
        ├── components/
        ├── services/
        ├── interfaces/
        └── interceptors/
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

Property listing supports page number, page size, search query, and status.

Example:

```text
GET /api/Property?pageNumber=1&pageSize=6&searchQuery=beach&status=true
```

## Image Upload

Property creation uses `multipart/form-data`.

Uploaded images are stored under:

```text
wwwroot/uploads/properties/
```

The API returns an `imageUrl` that the Angular application uses to display the image.

## Authentication Flow

```text
Login
  ↓
Angular AuthService
  ↓
POST /api/Auth/login
  ↓
JWT Token
  ↓
localStorage
  ↓
HTTP Interceptor
  ↓
Authorization: Bearer <token>
  ↓
Protected API
```

## Backend Setup

### Prerequisites

- .NET SDK
- SQL Server or Azure SQL
- Node.js
- Angular CLI

### 1. Configure the database

Add your connection string locally:

```json
{
  "ConnectionStrings": {
    "AppDbConnection": "YOUR_CONNECTION_STRING"
  }
}
```

Do not commit real credentials or secrets.

### 2. Apply migrations

```bash
dotnet ef database update --project AirbnbCloneBackend.Infrastructure --startup-project AirbnbCloneBackend.Api
```

If required:

```bash
dotnet tool install --global dotnet-ef
```

### 3. Run the API

```bash
dotnet run --project AirbnbCloneBackend.Api
```

## Frontend Setup

Install dependencies:

```bash
npm install
```

Configure the API URL in the Angular environment file:

```typescript
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7087/api'
};
```

Run Angular:

```bash
ng serve
```

Application:

```text
http://localhost:4200
```

## Angular Routes

```text
/login
/signup
/properties
/property/create
/property/{id}/edit
```

## Error Handling

The application handles:

- Form validation
- Loading states
- API errors
- 401 Unauthorized
- 403 Forbidden
- 404 Not Found
- 5xx server errors

The HTTP interceptor removes the stored JWT token when a `401 Unauthorized` response is received.

## Important Notes

- The real database connection string is intentionally excluded from the repository.
- Configure your own database connection before running the backend.
- Configure JWT secrets locally and do not commit production secrets.
- EF Core migration files are included.
- Uploaded property images are stored under `wwwroot/uploads/properties/`.

## Development Commands

Backend:

```bash
dotnet restore
dotnet build
dotnet run --project AirbnbCloneBackend.Api
```

Frontend:

```bash
npm install
ng serve
```

## License

Technical assignment / demonstration project.
