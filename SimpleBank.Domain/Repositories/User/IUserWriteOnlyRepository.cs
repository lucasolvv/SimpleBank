using SimpleBank.Domain.Entities;

namespace SimpleBank.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        public Task Add(Entities.User user);
    }
}
