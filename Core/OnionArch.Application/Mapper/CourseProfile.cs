using AutoMapper;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseViewModel>();
        CreateMap<AddCourseRequest, Course>();
        CreateMap<UpdateCourseRequest, Course>();
    }
}
