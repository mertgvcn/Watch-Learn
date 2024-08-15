using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Features.Students.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class CourseProfile : Profile
{
	public CourseProfile()
	{
		CreateMap<Course, CourseViewModel>();
		/*.ForMember(a => a.FirstName, opt => opt.MapFrom(src => src.Teacher.User.FirstName))
		.ForMember(a => a.LastName, opt => opt.MapFrom(src => src.Teacher.User.LastName))
		.ForMember(a => a.Email, opt => opt.MapFrom(src => src.Teacher.User.Email))*/
		CreateMap<AddCourseRequest, Course>();
		CreateMap<UpdateCourseRequest, Course>();
		CreateMap<Course, CourseDTO>();
		CreateMap<Course, MyCoursesViewModel>()
			.ForMember(a => a.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.FirstName + " " + src.Teacher.User.LastName));
	}
}
