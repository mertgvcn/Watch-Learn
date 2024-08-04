using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Students.Models;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly CancellationToken _cancellationToken;
    public StudentController(IStudentService studentService, ICancellationTokenService cancellationTokenService)
    {
        _studentService = studentService;
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

    [HttpPost]
    public async Task AddStudent([FromBody] AddStudentRequest request)
    {
        await _studentService.AddStudentAsync(request, _cancellationToken);
    }

    [HttpPatch]
    public async Task UpdateStudent([FromBody] UpdateStudentRequest request)
    {
        await _studentService.UpdateStudentAsync(request, _cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteStudent([FromQuery] long id)
    {
        await _studentService.DeleteStudentAsync(id, _cancellationToken);
    }

}
