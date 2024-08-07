using OnionArch.Application.Features.Lessons.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface ILessonService
{
    Task<List<LessonViewModel>> GetLessonsByCourseIdAsync(long courseId, CancellationToken cancellationToken);
    Task<LessonViewModel> GetLessonByIdAsync(long id, CancellationToken cancellationToken);
    Task AddLessonAsync(AddLessonRequest request, CancellationToken cancellationToken);
    Task UpdateLessonAsync(UpdateLessonRequest request, CancellationToken cancellationToken);
}
