using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Lessons;
using OnionArch.Application.Features.Lessons.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Lessons.Services;
public sealed class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IMapper _mapper;

    public LessonService(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<List<LessonViewModel>> GetLessonsByCourseIdAsync(long courseId, CancellationToken cancellationToken)
    {
        var lessons = await _lessonRepository.GetAllByCourseId(courseId)
            .ProjectTo<LessonViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return lessons;
    }

    public async Task<LessonViewModel> GetLessonByIdAsync(long id, CancellationToken cancellationToken)
    {
        var lesson = await _lessonRepository.GetById(id)
            .ProjectTo<LessonViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (lesson == null)
            throw new LessonNotFoundException($"Lesson with Id {id} returned null");

        return lesson;
    }

    public async Task AddLessonAsync(AddLessonRequest request, CancellationToken cancellationToken)
    {
        var newLesson = _mapper.Map<Lesson>(request);

        await _lessonRepository.AddAsync(newLesson, cancellationToken);
    }

    public async Task UpdateLessonAsync(UpdateLessonRequest request, CancellationToken cancellationToken)
    {
        var existingLesson = await _lessonRepository.GetByIdAsync(request.Id);

        if (existingLesson == null)
            throw new LessonNotFoundException($"Lesson with Id {request.Id} returned null");

        _mapper.Map(request, existingLesson);
        await _lessonRepository.UpdateAsync(existingLesson, cancellationToken);
    }

}
