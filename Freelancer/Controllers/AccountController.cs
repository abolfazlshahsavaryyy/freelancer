using Freelancer.Dtos;
using Freelancer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Freelancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };
            var result=await _userManager.CreateAsync(user,registerDto.Password);
            if (result.Succeeded)
            {
                return Ok("User Registered");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null || await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRole = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                authClaims.AddRange(userRole.Select(r => new Claim(ClaimTypes.Role, r)));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMin"]!)),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)), SecurityAlgorithms.HmacSha256)

                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("Add_role")]
        public async Task<IActionResult> AddRole([FromQuery] string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {

                var result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (result.Succeeded)
                {
                    return Ok("Role added succesfully");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return BadRequest("Role already is exists");
        }
        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRole model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound("user with this username is not exists ");
            }
            if(!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                return NotFound("this role is not exsits in definded roles");
            }
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded)
            {
                return Ok("role assign to the given user");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
