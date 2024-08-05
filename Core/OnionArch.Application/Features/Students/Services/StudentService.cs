using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Features.Students;
using OnionArch.Application.Features.Students.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Students.Services;
public sealed class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
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
        var student = await _studentRepository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (student == null)
            throw new StudentNotFoundException($"Student with Id {id} returned null");

        return student;
    }

    public async Task AddStudentAsync(AddStudentRequest request, CancellationToken cancellationToken)
    {
        var newStudent = _mapper.Map<Student>(request);

        await _studentRepository.AddAsync(newStudent, cancellationToken);
    }

    public async Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        var existingStudent = await _studentRepository.GetByIdAsync(request.Id);

        if (existingStudent == null)
            throw new StudentNotFoundException($"Student with Id {request.Id} returned null");

        _mapper.Map(request, existingStudent);
        await _studentRepository.UpdateAsync(existingStudent, cancellationToken);
    }

    public async Task DeleteStudentAsync(long id, CancellationToken cancellationToken)
    {
        await _studentRepository.DeleteAsync(id, cancellationToken);
    }
}
