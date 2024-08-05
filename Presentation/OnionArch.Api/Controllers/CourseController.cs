using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly CancellationToken _cancellationToken;
    public CourseController(ICourseService courseService, ICancellationTokenService cancellationTokenService)
    {
        _courseService = courseService;
        _cancellationToken = cancellationTokenService.cancellationToken;
    }

    [HttpGet]
    public async Task<ActionResult<List<CourseViewModel>>> GetAllCourses()
    {
        return Ok(await _courseService.GetAllCoursesAsync(_cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<CourseViewModel>> GetCourseById([FromQuery] long id)
    {
        return await _courseService.GetCourseByIdAsync(id, _cancellationToken);
    }

    [HttpPost]
    public async Task AddCourse([FromBody] AddCourseRequest request)
    {
        await _courseService.AddCourseAsync(request, _cancellationToken);
    }

    [HttpPatch]
    public async Task UpdateCourse([FromBody] UpdateCourseRequest request)
    {
        await _courseService.UpdateCourseAsync(request, _cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteCourse([FromQuery] long id)
    {
        await _courseService.DeleteCourseAsync(id, _cancellationToken);
    }
}
