using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Students;
using OnionArch.Application.Features.Students.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Application.Features.Students.Services;
public sealed class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IHttpContextService _httpContextService;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IHttpContextService httpContextService, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _httpContextService = httpContextService;
        _mapper = mapper;
    }

    public async Task<List<StudentViewModel>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAll()
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return students;
    }

    public async Task<StudentViewModel> GetStudentByIdAsync(long id, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetById(id)
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (student == null)
            throw new StudentNotFoundException($"Student with Id {id} returned null");

        return student;
    }

    public async Task<bool> IsCurrentStudentAttendedToCourseAsync(long courseId, CancellationToken cancellationToken)
    {
        var userId = await _httpContextService.GetCurrentUserIdAsync();
        var student = await _studentRepository.GetAll().Where(x => x.UserId == userId).Include(a => a.Courses).SingleAsync(cancellationToken);

        return student.Courses.Any(x => x.Id == courseId);
    }

    public async Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        var existingStudent = await _studentRepository.GetByIdAsync(request.Id);

        if (existingStudent == null)
            throw new StudentNotFoundException($"Student with Id {request.Id} returned null");

        _mapper.Map(request, existingStudent);
        await _studentRepository.UpdateAsync(existingStudent, cancellationToken);
    }

}
