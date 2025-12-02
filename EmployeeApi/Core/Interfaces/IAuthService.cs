using EmployeeApi.Core.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EmployeeApi.Core.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<string?> LoginAsync(LoginDto loginDto);
    }
}
