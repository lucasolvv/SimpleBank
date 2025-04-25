using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;
using SimpleBank.Application.Services;
using SimpleBank.Application.Services.Criptography;
namespace SimpleBank.Application.UseCases.User.Register
{
    public class CreateUserUseCase
    {
        public ResponseCreateUserJson Execute(RequestCreateUserJson request)
        {
            Validate(request);

            request.Password = PasswordEncripter.Encrypt(request.Password);
            
            // relacionar o user com a entidade do banco

            // criar o user no banco


            return new ResponseCreateUserJson
            {
                Nome = request.Name,
                Email = request.Email
            };
        }

        private void Validate(RequestCreateUserJson request)
        {
            var validator = new CreateUserValidator();
            
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Exception(string.Join(", ", errors));
            }
        }
    }
}
