using Asp.Versioning;
using EuphoriaCommerce.Application.Caching;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.CreateUser;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.GenerateNewAccessToken;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Login;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUserRole;
using EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsers;
using EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsersByRole;
using EuphoriaCommerce.Domain.CQRS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Euphoria_ecommerce.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController(Dispatcher dispatcher, IRedisCacheService cacheService) : AppControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("generate-new-access-token")]
        public async Task<IActionResult> GenerateNewAccessToken(TokenModel tokenModel)
        {
            var command = new GenerateNewAccessTokenCommand(tokenModel);
            var user = await dispatcher
                .SendCommandAsync<GenerateNewAccessTokenCommand, AuthenticationResponse>(command);
            return NewResult(user);
        }
        
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
        
        [AllowAnonymous]
        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var cache = cacheService.GetData<UserResponse<List<UserDto2>>>("Users");
            
            if (cache is not null)
            {
                return NewResult(cache);
            }

            var query = new GetUsersQuery();
            var response = await dispatcher.SendQueryAsync<GetUsersQuery, UserResponse<List<UserDto2>>>(query);
            cacheService.SetData("Users", response);
            return NewResult(response);
        }
        
        [AllowAnonymous]
        [HttpGet("Users/{role}")]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            var cache = cacheService.GetData<UserResponse<List<UserDto2>>>($"Users-{role}");
            
            if (cache is not null)
            {
                return NewResult(cache);
            }

            var query = new GetUsersByRoleQuery(role);
            var response = await dispatcher.SendQueryAsync<GetUsersByRoleQuery, UserResponse<List<UserDto2>>>(query);
            cacheService.SetData($"Users-{role}", response);
            return NewResult(response);
        }
        
        [AllowAnonymous]
        [HttpGet("User/{email}")]
        public async Task<string> GetUserRole(string email)
        {
            var cache = cacheService.GetData<string>($"User-{email}");
            
            if (cache is not null)
            {
                return cache;
            }

            var query = new GetUserRolesByEmailQuery(email);
            var response = await dispatcher.SendQueryAsync<GetUserRolesByEmailQuery, string>(query);
            cacheService.SetData($"User-{email}", response);
            return response;
        }
        
        [AllowAnonymous]
        [Consumes("multipart/form-data")]
        [HttpPost("create-user-with-profile")]
        public async Task<IActionResult> CreateUserWithProfile([FromForm] CreateUserWithProfileDto withProfileDto)
        {
            var command = new CreateUserWithProfileCommand(withProfileDto);
            var response = await dispatcher.SendCommandAsync<CreateUserWithProfileCommand, AuthenticationResponse>(command);
            return NewResult(response);
        }
    }
}
