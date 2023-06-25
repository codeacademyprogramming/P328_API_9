using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Api.Dtos.UserDtos;
using Shop.Api.Services;
using Shop.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,JwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized();

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized();
            
            var roles = await _userManager.GetRolesAsync(user);
         
            return Ok(_jwtService.GenerateToken(user,roles));
        }

    }
}
