using Microsoft.AspNetCore.Mvc;
using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;
using SimpleBank.Application.UseCases;
using SimpleBank.Application.UseCases.User.Register;

namespace SimpleBank.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {     

        [HttpPost("/register")]
        [ProducesResponseType(typeof(ResponseCreateUserJson), StatusCodes.Status201Created)]
        public IActionResult Resgister(RequestCreateUserJson request)
        {
            var useCase = new CreateUserUseCase();
            useCase.Execute(request);

            return Created();
        }
    }

    
   
}
