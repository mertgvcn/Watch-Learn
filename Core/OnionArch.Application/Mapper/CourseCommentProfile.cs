using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class CourseCommentProfile : Profile
{
	public CourseCommentProfile()
	{
		CreateMap<CourseComment, CourseCommentDTO>()
			.ForMember(a => a.StudentName, opt => opt.MapFrom(src => src.Student.User.FirstName + " " + src.Student.User.LastName));
	}
}
