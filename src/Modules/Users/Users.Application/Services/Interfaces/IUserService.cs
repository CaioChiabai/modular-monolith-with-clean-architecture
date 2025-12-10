using Users.Application.DTOs;
using Users.Domain.Entities;

namespace Users.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(CreateUserDto createUserDto);
        Task<User?> GetUserByIdAsync(int id);
    }
}
