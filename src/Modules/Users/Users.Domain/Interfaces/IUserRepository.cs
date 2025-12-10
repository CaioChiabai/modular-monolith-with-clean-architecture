using Users.Domain.Entities;

namespace Users.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(int id);
    }
}
