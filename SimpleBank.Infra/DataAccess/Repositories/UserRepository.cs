using SimpleBank.Infra.Context;
using SimpleBank.Domain.Entities;


using SimpleBank.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace SimpleBank.Infra.DataAccess.Repositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly SimpleBankDbContext _dbContext;
        public UserRepository(SimpleBankDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistActiveUserWithEmail(string email) => 
            await _dbContext.Users.AnyAsync(user =>  user.Email.Equals(email));

        public async Task<User> GetUserByEmail(string email) =>
            await _dbContext.Users
                .FirstOrDefaultAsync(user => user.Email.Equals(email));

        public async Task<bool> ExistActiveUserWithDocument(string document) =>
            await _dbContext.Users.AnyAsync(user => user.Document.Equals(document));



    }
}
