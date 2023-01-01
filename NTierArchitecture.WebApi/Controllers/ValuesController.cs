

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
