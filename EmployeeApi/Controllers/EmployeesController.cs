using EmployeeApi.Core.Entities;
using EmployeeApi.Core.Dtos;
using EmployeeApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralServiceResponseDto<IEnumerable<EmployeeDto>>>> GetEmployees()
        {
            var response = await _employeeService.GetAllEmployeesAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralServiceResponseDto<EmployeeDto>>> GetEmployee(int id)
        {
            var response = await _employeeService.GetEmployeeByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<GeneralServiceResponseDto<EmployeeDto>>> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var response = await _employeeService.CreateEmployeeAsync(createEmployeeDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralServiceResponseDto>> UpdateEmployee(int id, CreateEmployeeDto createEmployeeDto)
        {
            var response = await _employeeService.UpdateEmployeeAsync(id, createEmployeeDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralServiceResponseDto>> DeleteEmployee(int id)
        {
            var response = await _employeeService.DeleteEmployeeAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
