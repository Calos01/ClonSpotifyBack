﻿namespace ClonSpotifyBack.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean UserActive { get; set; }=true;
        public List<Playlist> Playlists { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
