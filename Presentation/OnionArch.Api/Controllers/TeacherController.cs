using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Teachers.Models;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;
[Route("api/[controller]/[Action]")]
[ApiController]
[Authorize]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    private readonly CancellationToken _cancellationToken;

    public TeacherController(ITeacherService teacherService, ICancellationTokenService cancellationTokenService)
    {
        _teacherService = teacherService;
        _cancellationToken = cancellationTokenService.cancellationToken;
    }

    [HttpGet]
    public async Task<List<TeacherViewModel>> GetAllTeachers()
    {
        return await _teacherService.GetAllTeachersAsync(_cancellationToken);
    }

    [HttpGet]
    public async Task<TeacherViewModel> GetTeacherById([FromQuery] long id)
    {
        return await _teacherService.GetTeacherByIdAsync(id, _cancellationToken);
    }

    [HttpPost]
    public async Task AddTeacher([FromBody] AddTeacherRequest request)
    {
        await _teacherService.AddTeacherAsync(request, _cancellationToken);
    }

    [HttpPatch]
    public async Task UpdateTeacher([FromBody] UpdateTeacherRequest request)
    {
        await _teacherService.UpdateTeacherAsync(request, _cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteTeacher([FromQuery] long id)
    {
        await _teacherService.DeleteTeacherAsync(id, _cancellationToken);
    }
}
