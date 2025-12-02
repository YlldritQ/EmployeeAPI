# Employee API

A .NET 8 Web API for managing employees.

## How to Run

### Using Docker (Recommended)

1.  Ensure you have Docker and Docker Compose installed.
2.  Navigate to the project root directory (where `docker-compose.yml` is located).
3.  Run the application:
    ```
    docker-compose up --build
    ```
4.  Access the services:
    *   **API & Swagger**: `http://localhost:5000/swagger`
    *   **Adminer (DB UI)**: `http://localhost:8081/?mssql=sql-server&username=sa&db=EmployeeDb` (Password: `YourStrong@Password`)

### Local Development (.NET CLI)

1.  Ensure you have the .NET 9 SDK installed.
2.  Navigate to the `EmployeeApi` directory.
3.  Update `appsettings.json` to point to a valid SQL Server instance or revert to InMemory.
4.  Run the application:
    ```bash
    dotnet run
    ```

## API Endpoints

### Authentication

> **Note**: All employee endpoints require authentication with a JWT token.

*   **POST /api/auth/register**: Register a new user.
    *   Body:
        ```json
        {
          "username": "myusername",
          "email": "user@example.com",
          "password": "MyPassword@123"
        }
        ```
    *   Response: `{"message": "User registered successfully"}`

*   **POST /api/auth/login**: Login to receive a JWT token.
    *   Body:
        ```json
        {
          "username": "myusername",
          "password": "MyPassword@123"
        }
        ```
    *   Response: `{"token": "eyJhbGci..."}`
    *   **Test Credentials**: For quick testing, you can use `username: "admin"` and `password: "admin"`

### Employees (Protected - Requires JWT Token)

*   **GET /api/employees**: Get all employees (includes Age).
*   **GET /api/employees/{id}**: Get a specific employee by ID.
*   **POST /api/employees**: Create a new employee.
    *   Body:
        ```json
        {
          "firstName": "John",
          "lastName": "Doe",
          "dateOfBirth": "1990-01-01",
          "educationLevel": "Bachelor"
        }
        ```
*   **PUT /api/employees/{id}**: Update an existing employee.
*   **DELETE /api/employees/{id}**: Delete an employee.

## How to Authenticate in Swagger

1. Navigate to Swagger UI at `http://localhost:5000/swagger` (or `http://localhost:5053` for local development)
2. Click the **Authorize** button (lock icon) at the top right
3. Get a token:
   - Option A: Use test credentials - Login with `username: "admin"` and `password: "admin"`
   - Option B: Register a new user at `/api/auth/register`, then login at `/api/auth/login`
4. Copy the token from the login response
5. In the "Authorize" dialog, enter: `Bearer <your-token-here>` (replace `<your-token-here>` with your actual token)
   - Example: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...`
6. Click **Authorize** and then **Close**
7. All requests will now include the JWT token in the Authorization header

## Technologies

*   .NET 9
*   ASP.NET Core Web API
*   Entity Framework Core (SQL Server)
*   ASP.NET Core Identity
*   JWT Bearer Authentication
*   AutoMapper
*   Docker , Docker Compose
