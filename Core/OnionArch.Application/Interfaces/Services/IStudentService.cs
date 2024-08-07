using OnionArch.Application.Features.Students.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface IStudentService
{
    Task<List<StudentViewModel>> GetAllStudentsAsync(CancellationToken cancellationToken);
    Task<StudentViewModel> GetStudentByIdAsync(long id, CancellationToken cancellationToken);
    Task AddStudentAsync(AddStudentRequest request, CancellationToken cancellationToken);
    Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken);
}
