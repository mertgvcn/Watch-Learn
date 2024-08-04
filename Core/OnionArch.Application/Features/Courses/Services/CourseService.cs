using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Courses.Services;
public sealed class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<List<CourseViewModel>> GetAllCoursesAsync()
    {
        var courses = await _courseRepository.GetAll()
            .Include(x => x.Students)
            .Include(x => x.Teacher)
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return courses;
    }

    public async Task<CourseViewModel> GetCourseByIdAsync(long id)
    {
        var course = await _courseRepository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .SingleAsync();

        return course;
    }

    public async Task AddCourseAsync(AddCourseRequest request)
    {
        var newCourse = new Course()
        {
            Title = request.Title,
            Description = request.Description,
            TeacherId = request.TeacherId
        };

        await _courseRepository.AddAsync(newCourse);
    }

    public async Task UpdateCourseAsync(UpdateCourseRequest request)
    {
        var existingCourse = await _courseRepository.GetByIdAsync(request.Id);
        if (existingCourse is null)
            throw new Exception("Course is not exist");

        existingCourse.Title = request.Title;
        existingCourse.Description = request.Description;
        existingCourse.TeacherId = request.TeacherId;

        await _courseRepository.UpdateAsync(existingCourse);
    }

    public async Task DeleteCourseAsync(long id)
    {
        await _courseRepository.DeleteAsync(id);
    }
}
