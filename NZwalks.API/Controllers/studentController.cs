using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetActionResult()
        {
            string[] studentNames = new string[] { "pranav", "uday", "priyanshu", "dravid" };

            return Ok(studentNames);
        }
    }
}
