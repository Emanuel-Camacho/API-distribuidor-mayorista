using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductDbContext _dbContext;

        public UserRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUser(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}