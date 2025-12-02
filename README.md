# Employee API

A .NET 8 Web API for managing employees.

## How to Run

### Using Docker (Recommended)

1.  Ensure you have Docker and Docker Compose installed.
2.  Navigate to the project root directory (where `docker-compose.yml` is located).
3.  Run the application:
    ```bash
    docker-compose up --build
    ```
4.  Access the services:
    *   **API & Swagger**: `http://localhost:5000/swagger`
    *   **Adminer (DB UI)**: `http://localhost:8081/?mssql=sql-server&username=sa&db=EmployeeDb` (Password: `YourStrong@Password`)

### Local Development (.NET CLI)

1.  Ensure you have the .NET 8 SDK installed.
2.  Navigate to the `EmployeeApi` directory.
3.  Update `appsettings.json` to point to a valid SQL Server instance or revert to InMemory.
4.  Run the application:
    ```bash
    dotnet run
    ```

## API Endpoints

### Employees

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

## Technologies

*   .NET 8
*   ASP.NET Core Web API
*   Entity Framework Core (InMemory)
*   AutoMapper
