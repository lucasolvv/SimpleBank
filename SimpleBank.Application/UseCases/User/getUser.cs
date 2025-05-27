using SimpleBank.Domain.Repositories.User;


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

        public async Task<IEnumerable<Domain.Entities.User>> getAllUsers()
        {
            var users = await _userReadOnlyRepository.GetAllUsers();
            return users;
        }
    }
}
