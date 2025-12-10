using Users.Application.DTOs;
using Users.Application.Services.Interfaces;
using Users.Domain.Entities;
using Users.Domain.Interfaces;

namespace Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User(dto.Name, dto.Email);

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
