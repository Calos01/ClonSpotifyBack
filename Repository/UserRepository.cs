using AutoMapper;
using ClonSpotifyBack.ContextBD;
using ClonSpotifyBack.DTO;
using ClonSpotifyBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ClonSpotifyBack.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly SpotifyDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(SpotifyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> GetUser(UserDTO userdto)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userdto.Email);
            return user;
        }

        public async Task<string> RegisterUser(RegistroDTO regdto)
        {
            var user=await _context.Users.FirstOrDefaultAsync(x=>x.Email == regdto.Email);
            
            string res = "";
            if (user == null)
            {
                var userreg = _mapper.Map<User>(regdto);
                userreg.CreatedAt= DateTime.Now;
                userreg.UserActive= true;
                await _context.AddAsync<User>(userreg);
                _context.SaveChanges();
                res = "usuario registrado";
            }
            else
            {
                res="usuario ya existe";

            }
            return res;
        }
    }
}
