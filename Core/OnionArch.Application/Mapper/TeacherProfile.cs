using AutoMapper;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherCourseViewModel>();
    }
}
