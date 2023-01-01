using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Core.Utilities.Security;

namespace NTierArchitecture.WebApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]    
    public class AuthController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;

        public AuthController(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        public IActionResult Login()
        {
            var token = _tokenHandler.CreateToken();
            return Ok(token);
        }
    }
}
