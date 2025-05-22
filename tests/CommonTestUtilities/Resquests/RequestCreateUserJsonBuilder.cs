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
                .RuleFor(x => x.Password, f => GenerateValidPassword(f))
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.Document, f => f.Random.Replace("###.###.###-##"))
                .RuleFor(x => x.AccountType, f => f.PickRandom<accountTypes>().ToString())
                .Generate();
        }
        private static string GenerateValidPassword(Faker f)
        {
            // Gera uma senha entre 8 e 12 caracteres, contendo pelo menos 1 maiúscula, 1 minúscula e 1 número
            var upper = f.Random.Char('A', 'Z');
            var lower = f.Random.Char('a', 'z');
            var digit = f.Random.Number(0, 9).ToString();
            var rest = f.Random.String2(f.Random.Int(5, 9), "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");

            // Junta e embaralha os caracteres
            var password = $"{upper}{lower}{digit}{rest}";
            return new string(password.ToCharArray().OrderBy(_ => f.Random.Int()).ToArray());
        }
    }
        public enum accountTypes
        {
            Common,
            Merchant
        }
}
