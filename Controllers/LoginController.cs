using AutoMapper;
using ClonSpotifyBack.DTO;
using ClonSpotifyBack.Models;
using ClonSpotifyBack.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClonSpotifyBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        public LoginController(IMapper mapper, IUserRepository userRepo, IConfiguration config)
        {
            _mapper = mapper;
            _userRepo = userRepo;   
            _config = config;
        }
        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate(UserDTO userdto)
        {
            try
            {
                if (userdto == null) {
                    return BadRequest();
                }
                else
                {
                    var userauth = await _userRepo.GetUser(userdto); 
                    if(userauth is null)
                    {
                        return BadRequest(new {message="credenciales incorrectas"});
                    }
                    else
                    {
                        string tokenauth = GenerarToken(userauth);
                        return Ok(new { token=tokenauth });
                    }
                } 
            }catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        private string GenerarToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
                );
            string token= new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

    }
}
