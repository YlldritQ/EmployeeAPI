using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Employees (FirstName, LastName, DateOfBirth, EducationLevel)
                VALUES 
                    ('John', 'Doe', '1990-01-15', 'Bachelor'),
                    ('Jane', 'Smith', '1985-06-20', 'Master'),
                    ('Alice', 'Johnson', '1995-03-10', 'PhD'),
                    ('Bob', 'Williams', '1992-11-05', 'Bachelor'),
                    ('Carol', 'Brown', '1988-08-25', 'Master');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM Employees 
                WHERE FirstName IN ('John', 'Jane', 'Alice', 'Bob', 'Carol')
                  AND LastName IN ('Doe', 'Smith', 'Johnson', 'Williams', 'Brown');
            ");
        }
    }
}
