using IdentityServer.Domain.Dtos;
using IdentityServer.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServer.API.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;
    public UserController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _authService.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetUserById([FromRoute] long id)
    {
        return Ok(await _authService.GetById(id));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> UpdateUser(long id, [FromBody] UserDto request)
    {
        await _authService.Update(id, request);
        return Ok("User updated successfully.");
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> DeleteUser(long id)
    {
        await _authService.Delete(id);
        return Ok("User deleted successfully.");
    }
}
