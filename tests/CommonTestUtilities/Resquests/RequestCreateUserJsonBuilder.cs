using Bogus;
using SimpleBank.Communication.Requests;

namespace CommonTestUtilities.Resquests
{
    public class RequestCreateUserJsonBuilder
    {   
        public static RequestCreateUserJson Build()
        {
            return new Faker<RequestCreateUserJson>()
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Password, f => f.Internet.Password(8))
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.Document, f => f.Random.Replace("###.###.###-##"))
                .RuleFor(x => x.AccountType, f => f.PickRandom<accountTypes>().ToString())
                .Generate();
        }
    }
        public enum accountTypes
        {
            Common,
            Merchant
        }
}
