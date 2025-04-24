using Microsoft.AspNetCore.Mvc;
using SimpleBank.Communication.Requests;
using SimpleBank.Communication.Responses;

namespace SimpleBank.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("/{name}")]
        public ActionResult HelloWord(string name)
        {
            return Ok($"Hello {name}!");
        }

        [HttpPost("/register")]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Resgister(RequestRegisterUserJson request)
        {
            return Created();
        }
    }

    
   
}
