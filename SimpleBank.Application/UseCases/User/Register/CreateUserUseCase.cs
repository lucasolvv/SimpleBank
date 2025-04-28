using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;
using SimpleBank.Application.Services;
using SimpleBank.Application.Services.Criptography;
using SimpleBank.Domain.Repositories.User;
using Microsoft.Extensions.Options;
using AutoMapper;
using SimpleBank.Domain.Entities;
using System.Threading.Tasks;
namespace SimpleBank.Application.UseCases.User.Register
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IMapper _mapper;

        public CreateUserUseCase(
            IUserWriteOnlyRepository userWriteOnlyRepository, 
            IUserReadOnlyRepository userReadOnlyRepository,
            IMapper mapper
            )
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _mapper = mapper;
        }
        
        public async Task<ResponseCreateUserJson> Execute(RequestCreateUserJson request)
        {
            Validate(request);
            //var userExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = PasswordEncripter.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);


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
