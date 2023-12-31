﻿using ClonSpotifyBack.DTO;
using ClonSpotifyBack.Models;

namespace ClonSpotifyBack.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetUser(UserDTO userdto);
        public Task<string> RegisterUser(RegistroDTO regdto);
    }
}
