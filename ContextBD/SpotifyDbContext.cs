using ClonSpotifyBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ClonSpotifyBack.ContextBD
{
    public class SpotifyDbContext:DbContext
    {
        public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options):base (options)
        {
            
        }
        public DbSet<User> Users { get; set; }   
        public DbSet<Music> Musics { get; set; }   
        public DbSet<Playlist> Playlists { get; set; }   
        public DbSet<Genere> Generes { get; set; }   

    }
}
