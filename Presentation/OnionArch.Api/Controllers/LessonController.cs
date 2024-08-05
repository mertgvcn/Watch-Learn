using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Lessons.Models;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;
    private readonly CancellationToken _cancellationToken;

    public LessonController(ILessonService lessonService, ICancellationTokenService cancellationTokenService)
    {
        _lessonService = lessonService;
        _cancellationToken = cancellationTokenService.cancellationToken;
    }

    [HttpGet]
    public async Task<ActionResult<List<LessonViewModel>>> GetLessonsByCourseId([FromQuery] long courseId)
    {
        return await _lessonService.GetLessonsByCourseIdAsync(courseId, _cancellationToken);
    }

    [HttpGet]
    public async Task<ActionResult<LessonViewModel>> GetLessonById([FromQuery] long id)
    {
        return await _lessonService.GetLessonByIdAsync(id, _cancellationToken);
    }

    [HttpPost]
    public async Task AddLesson([FromBody] AddLessonRequest request)
    {
        await _lessonService.AddLessonAsync(request, _cancellationToken);
    }

    [HttpPatch]
    public async Task UpdateLesson([FromBody] UpdateLessonRequest request)
    {
        await _lessonService.UpdateLessonAsync(request, _cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteLesson([FromQuery] long id)
    {
        await _lessonService.DeleteLessonAsync(id, _cancellationToken);
    }
}
