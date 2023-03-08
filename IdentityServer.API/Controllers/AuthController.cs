using IdentityServer.Domain.Dtos;
using IdentityServer.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

    public async Task<IActionResult> Register([FromBody] UserRegisterDto request)
    {
        await _authService.Add(request);
        return Ok("User created successfully.");
    }

    [HttpPost("Login")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> Login([FromBody] UserLoginDto request)
    {
        var token = await _authService.Login(request);
        return Ok(token);
    }
}