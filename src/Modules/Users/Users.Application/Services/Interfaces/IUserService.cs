using Users.Application.DTOs;

namespace Users.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserResponseDto?> GetUserByIdAsync(int id);
    }
}
