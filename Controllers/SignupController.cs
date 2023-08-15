using AutoMapper;
using ClonSpotifyBack.DTO;
using ClonSpotifyBack.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClonSpotifyBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        
        public SignupController(IMapper mapper, IUserRepository repo)
        {
            _mapper = mapper;  
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegistroDTO regdto)
        {
            try
            {
                var res= await _repo.RegisterUser(regdto);
                return Ok(res);  

            }catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

    }
}
