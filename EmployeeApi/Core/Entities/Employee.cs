using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;
        
        public DateOnly DateOfBirth { get; set; }
        
        public string EducationLevel { get; set; } = string.Empty;
    }
}
