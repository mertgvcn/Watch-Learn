using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Exceptions.Courses;
using OnionArch.Application.Features.Courses.Models.Parameters;
using OnionArch.Application.Features.Courses.Models.Views;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController : ControllerBase
{
	private readonly ICourseService _courseService;
	private readonly ICourseRepository _courseRepository;
	private readonly CancellationToken _cancellationToken;

	public CourseController(ICourseService courseService, ICourseRepository courseRepository, ICancellationTokenService cancellationTokenService)
	{
		_courseService = courseService;
		_courseRepository = courseRepository;
		_cancellationToken = cancellationTokenService.cancellationToken;
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<ActionResult<List<CourseViewModel>>> GetAllCourses()
	{
		return Ok(await _courseService.GetAllCoursesAsync(_cancellationToken));
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<ActionResult<CourseDetailViewModel>> GetCourseDetailById([FromQuery] long id)
	{
		return Ok(await _courseService.GetCourseDetailByIdAsync(id, _cancellationToken));
	}

	[HttpGet]
	[Authorize]
	public async Task<ActionResult<List<CurrentStudentCourseViewModel>>> GetCurrentStudentCourses()
	{
		return Ok(await _courseService.GetCurrentStudentCoursesAsync(_cancellationToken));
	}

	[HttpPost]
	[Authorize]
	public async Task<ActionResult> EnrollCurrentUserInCourse([FromBody] EnrollCurrentUserInCourseRequest request)
	{
		try
		{
			await _courseService.EnrollCurrentUserInCourseAsync(request, _cancellationToken);
			return Ok();
		}
		catch (CourseNotFoundException)
		{
			return NotFound();
		}
	}

	[HttpPost]
	[Authorize]
	public async Task AddCourse([FromBody] AddCourseRequest request)
	{
		await _courseService.AddCourseAsync(request, _cancellationToken);
	}

	[HttpPatch]
	[Authorize]
	public async Task UpdateCourse([FromBody] UpdateCourseRequest request)
	{
		await _courseService.UpdateCourseAsync(request, _cancellationToken);
	}

	[HttpDelete]
	[Authorize]
	public async Task DeleteCourse([FromQuery] long id)
	{
		await _courseRepository.DeleteAsync(id, _cancellationToken);
	}
}
