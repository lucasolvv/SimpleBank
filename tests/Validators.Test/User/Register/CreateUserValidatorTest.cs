using Xunit;
using FluentValidation.TestHelper;
using SimpleBank.Application.UseCases.User.Register;
using SimpleBank.Communication.Requests;
using CommonTestUtilities.Resquests;
using Shouldly;

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
        public void Success()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            var result = _validator.Validate(request);
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.Name = string.Empty;    
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Too_Short()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.Name = "F";
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.Password = string.Empty;
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse(); 
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Weak()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.Password = "1234";
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.Email = "invalid-email1111";
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_Document_Is_Empty()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.Document = string.Empty;
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_AccountType_Is_Invalid()
        {
            var request = RequestCreateUserJsonBuilder.Build();
            request.AccountType = "InvalidAccountType";
            var result = _validator.TestValidate(request);
            result.IsValid.ShouldBeFalse();
        }

        [Fact]
        public void Should_Not_Have_Error_When_Model_Is_Valid()
        {
            var model = RequestCreateUserJsonBuilder.Build();
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
