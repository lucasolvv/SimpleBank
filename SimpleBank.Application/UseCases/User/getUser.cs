using SimpleBank.Application.Services.Criptography;
using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;
using SimpleBank.Domain.Entities;
using SimpleBank.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Application.UseCases.User
{
    public class getUser : IgetUser
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public getUser(IUserReadOnlyRepository userReadOnlyRepository)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
        }
        public async Task<Domain.Entities.User> Execute(string email)
        {

            var user = await _userReadOnlyRepository.GetUserByEmail(email);


            return user;
        }
    }
}
