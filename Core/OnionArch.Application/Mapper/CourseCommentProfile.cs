using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class CourseCommentProfile : Profile
{
    public CourseCommentProfile()
    {
        CreateMap<CourseComment, CourseCommentDTO>();
    }
}
