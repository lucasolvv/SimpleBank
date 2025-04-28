using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;

namespace SimpleBank.Application.UseCases.User.Register
{
    public interface ICreateUserUseCase
    {
        Task<ResponseCreateUserJson> Execute(RequestCreateUserJson request);
    }
}
