using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
        var students = await _studentRepository.GetAll() //courses ve progress gerektiğinde çekilmesi daha doğru demi?
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return students;
    }

    public async Task<StudentViewModel> GetStudentByIdAsync(long id, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken);

        return student;
    }

    public async Task AddStudentAsync(AddStudentRequest request, CancellationToken cancellationToken)
    {
        await _studentRepository.AddAsync(_mapper.Map<Student>(request), cancellationToken);
    }

    public async Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        var existingStudent = await _studentRepository.GetByIdAsync(request.Id);
        if (existingStudent is null)
            throw new Exception("Student is not exist");

        _mapper.Map(request, existingStudent);
        await _studentRepository.UpdateAsync(existingStudent, cancellationToken);
    }

    public async Task DeleteStudentAsync(long id, CancellationToken cancellationToken)
    {
        await _studentRepository.DeleteAsync(id, cancellationToken);
    }
}
