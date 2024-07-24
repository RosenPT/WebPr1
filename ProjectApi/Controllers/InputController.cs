using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InputController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] int input)
        {
            if (input == 1)
            {
                return StatusCode(203);
            }
            return BadRequest("Invalid input");
        }
    }
}