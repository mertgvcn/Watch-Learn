using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Application.Features.Courses.Models.Parameters;
using OnionArch.Application.Features.Courses.Models.Views;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class CourseProfile : Profile
{
	public CourseProfile()
	{
		CreateMap<Course, CourseViewModel>()
			.ForMember(a => a.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.FirstName + " " + src.Teacher.User.LastName))
			.ForMember(a => a.LessonCount, opt => opt.MapFrom(src => src.Lessons.Count))
			.ForMember(a => a.TotalLessonDuration, opt => opt.MapFrom(src => src.Lessons.Sum(a => a.DurationInSeconds)));

		CreateMap<Course, CurrentStudentCourseViewModel>()
			.ForMember(a => a.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.FirstName + " " + src.Teacher.User.LastName));
		//.ForMember(a => a.StudentProgressPercentage, opt => opt.MapFrom<StudentProgressResolver>());

		CreateMap<AddCourseRequest, Course>();
		CreateMap<UpdateCourseRequest, Course>();
		CreateMap<Course, CourseDTO>();
	}
}

