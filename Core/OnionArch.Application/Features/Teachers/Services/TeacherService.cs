using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Teachers;
using OnionArch.Application.Features.Teachers.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Teachers.Services;
public sealed class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;
    public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;

    }

    public async Task<List<TeacherViewModel>> GetAllTeachersAsync(CancellationToken cancellationToken)
    {
        var teachers = await _teacherRepository.GetAll()
            .ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return teachers;
    }

    public async Task<TeacherViewModel> GetTeacherByIdAsync(long id, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetById(id)
            .ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (teacher == null)
            throw new TeacherNotFoundException($"Teacher with Id {id} returned null");

        return teacher;
    }

    public async Task AddTeacherAsync(AddTeacherRequest request, CancellationToken cancellationToken)
    {
        var newTeacher = _mapper.Map<Teacher>(request);

        await _teacherRepository.AddAsync(newTeacher, cancellationToken);
    }

    public async Task UpdateTeacherAsync(UpdateTeacherRequest request, CancellationToken cancellationToken)
    {
        var existingTeacher = await _teacherRepository.GetByIdAsync(request.Id);

        if (existingTeacher == null)
            throw new TeacherNotFoundException($"Teacher with Id {request.Id} returned null");

        _mapper.Map(request, existingTeacher);
        await _teacherRepository.UpdateAsync(existingTeacher, cancellationToken);
    }

}
