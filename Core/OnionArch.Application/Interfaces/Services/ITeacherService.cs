using OnionArch.Application.Features.Teachers.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface ITeacherService
{
    Task<List<TeacherViewModel>> GetAllTeachersAsync(CancellationToken cancellationToken);
    Task<TeacherViewModel> GetTeacherByIdAsync(long id, CancellationToken cancellationToken);
    Task AddTeacherAsync(AddTeacherRequest request, CancellationToken cancellationToken);
    Task UpdateTeacherAsync(UpdateTeacherRequest request, CancellationToken cancellationToken);
}
