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
        public UserRepository(SpotifyDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(UserDTO userdto)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userdto.Email);
            return user;
        }
    }
}
