using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.WebApi.Abstractions;
[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
}
