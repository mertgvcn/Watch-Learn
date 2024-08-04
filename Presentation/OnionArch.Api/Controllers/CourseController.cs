using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /* hangisi daha mantıklı veya doğru
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        return Ok(await _courseService.GetAllCoursesAsync());
    }
    */

    [HttpGet]
    public async Task<List<CourseViewModel>> GetAllCourses()
    {
        return await _courseService.GetAllCoursesAsync();
    }

    [HttpGet]
    public async Task<CourseViewModel> GetCourseById([FromQuery] long id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

    [HttpPost]
    public async Task AddCourse([FromBody] AddCourseRequest request)
    {
        await _courseService.AddCourseAsync(request);
    }

    [HttpPut] //HttpPatch?
    public async Task UpdateCourse([FromBody] UpdateCourseRequest request)
    {
        await _courseService.UpdateCourseAsync(request);
    }

    [HttpDelete]
    public async Task DeleteCourse([FromQuery] long id)
    {
        await _courseService.DeleteCourseAsync(id);
    }

}
