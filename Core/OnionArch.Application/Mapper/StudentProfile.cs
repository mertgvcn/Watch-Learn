using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Application.Features.Students.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentViewModel>();
        CreateMap<AddStudentRequest, Student>();
        CreateMap<UpdateStudentRequest, Student>();
        CreateMap<Student, StudentDTO>();
    }
}
