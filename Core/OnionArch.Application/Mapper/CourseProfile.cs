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
			.ForMember(a => a.Price, opt => opt.MapFrom(src => Math.Round(src.Price, 2)))
			.ForMember(a => a.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.FirstName + " " + src.Teacher.User.LastName))
			.ForMember(a => a.LessonCount, opt => opt.MapFrom(src => src.Lessons.Count))
			.ForMember(a => a.TotalLessonDurationInSeconds, opt => opt.MapFrom(src => src.Lessons.Sum(a => a.DurationInSeconds)));

		CreateMap<Course, CourseDetailViewModel>()
			.ForMember(a => a.Price, opt => opt.MapFrom(src => Math.Round(src.Price, 2)))
			.ForMember(a => a.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.FirstName + " " + src.Teacher.User.LastName))
			.ForMember(a => a.StudentCount, opt => opt.MapFrom(src => src.Students.Count))
			.ForMember(a => a.LessonCount, opt => opt.MapFrom(src => src.Lessons.Count))
			.ForMember(a => a.TotalLessonDurationInSeconds, opt => opt.MapFrom(src => src.Lessons.Sum(a => a.DurationInSeconds)));

		CreateMap<Course, CurrentStudentCourseViewModel>()
			.ForMember(a => a.TeacherName, opt => opt.MapFrom(src => src.Teacher.User.FirstName + " " + src.Teacher.User.LastName));

		CreateMap<AddCourseRequest, Course>();
		CreateMap<UpdateCourseRequest, Course>();
		CreateMap<Course, CourseDTO>();
	}
}

