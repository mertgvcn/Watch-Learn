﻿using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Application.Features.Auth.Models;
using OnionArch.Application.Features.Users.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<UserRegisterRequest, User>();
        CreateMap<User, UserDTO>();
    }
}
