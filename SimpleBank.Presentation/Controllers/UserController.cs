using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBank.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("/{name}")]
        public ActionResult HelloWord(string name)
        {
            return Ok($"Hello {name}!");
        }
    }
}
