using Microsoft.AspNetCore.Mvc;
using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;
using SimpleBank.Application.UseCases;
using SimpleBank.Application.UseCases.User.Register;
using SimpleBank.Domain.Entities;
using SimpleBank.Application.UseCases.User;

namespace SimpleBank.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase    
    {

        [HttpPost("/register")]
        [ProducesResponseType(typeof(ResponseCreateUserJson), StatusCodes.Status201Created)]
        public IActionResult Resgister([FromBody]RequestCreateUserJson request, [FromServices]ICreateUserUseCase useCase)
        {
            useCase.Execute(request);
            return Created();
        }

        [HttpGet("/getuser/{email}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public IActionResult GetUser(string email, [FromServices] IgetUser getuser)
        {
            var user = getuser.Execute(email);
            return Ok(user);
        }
    }

    
   
}
