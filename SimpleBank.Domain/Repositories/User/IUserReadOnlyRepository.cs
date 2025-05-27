namespace SimpleBank.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<Entities.User> GetUserByEmail(string email);
        public Task<bool> ExistActiveUserWithEmail(string email);
        public Task<bool> ExistActiveUserWithDocument(string document);
        public Task<IEnumerable<Entities.User>> GetAllUsers();
    }
}