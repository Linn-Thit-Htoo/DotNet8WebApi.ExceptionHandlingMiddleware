using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.ExceptionHandlingMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult SampleEndpoint(int num)
        {
            try
            {
                int result = 10 / num;
                return Ok("Hello!");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
