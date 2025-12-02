using AutoMapper;
using EmployeeApi.Core.Dtos;
using EmployeeApi.Core.Entities;
using EmployeeApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GeneralServiceResponseDto<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return new GeneralServiceResponseDto<IEnumerable<EmployeeDto>>
            {
                IsSucceed = true,
                StatusCode = 200,
                Message = "Employees retrieved successfully",
                Data = employeeDtos
            };
        }

        public async Task<GeneralServiceResponseDto<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return new GeneralServiceResponseDto<EmployeeDto>
                {
                    IsSucceed = false,
                    StatusCode = 404,
                    Message = $"Employee with ID {id} not found",
                    Data = null
                };
            }

            return new GeneralServiceResponseDto<EmployeeDto>
            {
                IsSucceed = true,
                StatusCode = 200,
                Message = "Employee retrieved successfully",
                Data = _mapper.Map<EmployeeDto>(employee)
            };
        }

        public async Task<GeneralServiceResponseDto<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDto);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return new GeneralServiceResponseDto<EmployeeDto>
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "Employee created successfully",
                Data = _mapper.Map<EmployeeDto>(employee)
            };
        }

        public async Task<GeneralServiceResponseDto> UpdateEmployeeAsync(int id, CreateEmployeeDto createEmployeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return new GeneralServiceResponseDto
                {
                    IsSucceed = false,
                    StatusCode = 404,
                    Message = $"Employee with ID {id} not found"
                };
            }

            _mapper.Map(createEmployeeDto, employee);
            await _context.SaveChangesAsync();

            return new GeneralServiceResponseDto
            {
                IsSucceed = true,
                StatusCode = 200,
                Message = "Employee updated successfully"
            };
        }

        public async Task<GeneralServiceResponseDto> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return new GeneralServiceResponseDto
                {
                    IsSucceed = false,
                    StatusCode = 404,
                    Message = $"Employee with ID {id} not found"
                };
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return new GeneralServiceResponseDto
            {
                IsSucceed = true,
                StatusCode = 200,
                Message = "Employee deleted successfully"
            };
        }
    }
}
