using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Application.Features.Teachers.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherViewModel>();
        CreateMap<AddTeacherRequest, Teacher>();
        CreateMap<UpdateTeacherRequest, Teacher>();
        CreateMap<Teacher, TeacherDTO>();
    }
}
