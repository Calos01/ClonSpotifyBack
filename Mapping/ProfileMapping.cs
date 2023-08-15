using AutoMapper;
using ClonSpotifyBack.DTO;
using ClonSpotifyBack.Models;

namespace ClonSpotifyBack.Mapping
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User,RegistroDTO>().ReverseMap();
            CreateMap<Music,MusicDTO>().ReverseMap();
            CreateMap<Playlist,PlaylistDTO>().ReverseMap();
            CreateMap<Genere,GenereDTO>().ReverseMap();

        }
    }
}
