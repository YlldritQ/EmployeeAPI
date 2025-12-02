using EmployeeApi.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<GeneralServiceResponseDto<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync();
        Task<GeneralServiceResponseDto<EmployeeDto>> GetEmployeeByIdAsync(int id);
        Task<GeneralServiceResponseDto<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<GeneralServiceResponseDto> UpdateEmployeeAsync(int id, CreateEmployeeDto createEmployeeDto);
        Task<GeneralServiceResponseDto> DeleteEmployeeAsync(int id);
    }
}
