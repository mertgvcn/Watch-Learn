using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherDTO>();
    }
}
