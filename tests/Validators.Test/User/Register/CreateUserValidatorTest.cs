using Xunit;
using FluentValidation.TestHelper;
using SimpleBank.Application.UseCases.User.Register;
using SimpleBank.Communication.Requests;

namespace SimpleBank.Tests.Validators.User.Register
{
    public class CreateUserValidatorTest
    {
        private readonly CreateUserValidator _validator;

        public CreateUserValidatorTest()
        {
            _validator = new CreateUserValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new RequestCreateUserJson { Name = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Too_Short()
        {
            var model = new RequestCreateUserJson { Name = "A" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var model = new RequestCreateUserJson { Password = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Weak()
        {
            var model = new RequestCreateUserJson { Password = "abc" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var model = new RequestCreateUserJson { Email = "invalid-email" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Document_Is_Empty()
        {
            var model = new RequestCreateUserJson { Document = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Document);
        }

        [Fact]
        public void Should_Have_Error_When_AccountType_Is_Invalid()
        {
            var model = new RequestCreateUserJson { AccountType = "InvalidType" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.AccountType);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Model_Is_Valid()
        {
            var model = new RequestCreateUserJson
            {
                Name = "João Silva",
                Password = "Senha123",
                Email = "joao@email.com",
                Document = "123.456.789-09", // Supondo que seja válido
                AccountType = "common"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
