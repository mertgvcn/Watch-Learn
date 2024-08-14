using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Students.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IStudentRepository _studentRepository;
    private readonly CancellationToken _cancellationToken;

    public StudentController(IStudentService studentService, IStudentRepository studentRepository, ICancellationTokenService cancellationTokenService)
    {
        _studentService = studentService;
        _studentRepository = studentRepository;
        _cancellationToken = cancellationTokenService.cancellationToken;
    }

    [HttpGet]
    public async Task<List<StudentViewModel>> GetAllStudents()
    {
        return await _studentService.GetAllStudentsAsync(_cancellationToken);
    }

    [HttpGet]
    public async Task<StudentViewModel> GetStudentById([FromQuery] long id)
    {
        return await _studentService.GetStudentByIdAsync(id, _cancellationToken);
    }

    [HttpGet]
    public async Task<bool> IsCurrentStudentAttendedToCourse([FromQuery] long courseId)
    {
        return await _studentService.IsCurrentStudentAttendedToCourseAsync(courseId, _cancellationToken);
    }

    [HttpPatch]
    public async Task UpdateStudent([FromBody] UpdateStudentRequest request)
    {
        await _studentService.UpdateStudentAsync(request, _cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteStudent([FromQuery] long id)
    {
        await _studentRepository.DeleteAsync(id, _cancellationToken);
    }
}
