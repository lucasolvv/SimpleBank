using SimpleBank.Communication.Requests;

namespace SimpleBank.Application.UseCases.User
{
    public interface IgetUser
    {
        Task<Domain.Entities.User> Execute(string request);
        Task<IEnumerable<Domain.Entities.User>> getAllUsers();
    }
}