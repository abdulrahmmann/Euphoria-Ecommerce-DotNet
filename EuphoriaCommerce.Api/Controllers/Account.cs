using Asp.Versioning;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Login;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Euphoria_ecommerce.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class Account(Dispatcher dispatcher) : AppControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            var command = new RegisterUserCommand(userDto);
            var result = await dispatcher.SendCommandAsync<RegisterUserCommand, AuthenticationResponse>(command);
            return NewResult(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            var command = new LoginUserCommand(userDto);
            var result = await dispatcher.SendCommandAsync<LoginUserCommand, AuthenticationResponse>(command);
            return NewResult(result);
        }
        
    }
}
