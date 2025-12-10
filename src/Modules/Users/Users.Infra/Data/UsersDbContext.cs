using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infra.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Boa prática separar os modulos por SCHEMA no banco
            modelBuilder.HasDefaultSchema("users_module");

            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }
}
