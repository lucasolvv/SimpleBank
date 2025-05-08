using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;
using SimpleBank.Application.Services;
using SimpleBank.Application.Services.Criptography;
using SimpleBank.Domain.Repositories.User;
using Microsoft.Extensions.Options;
using AutoMapper;
using SimpleBank.Domain.Entities;
using System.Threading.Tasks;
using SimpleBank.Exceptions.ExceptionsBase;
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
            await Validate(request);
            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = PasswordEncripter.Encrypt(request.Password);
            
            await _userWriteOnlyRepository.Add(user);


            return new ResponseCreateUserJson
            {
                Nome = request.Name,
                Email = request.Email
            };
        }

        private async Task Validate(RequestCreateUserJson request)
        {
            var validator = new CreateUserValidator();
            var result = validator.Validate(request);

            var emailExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
            var documentExists = await _userReadOnlyRepository.ExistActiveUserWithDocument(request.Document);

            if (emailExists) result.Errors.Add(new FluentValidation.Results.ValidationFailure("Email", "Email already registered"));            
            if (documentExists) result.Errors.Add(new FluentValidation.Results.ValidationFailure("Document", "Document already registered"));
            

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
