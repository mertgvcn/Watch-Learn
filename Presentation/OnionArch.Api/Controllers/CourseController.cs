using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Courses.Queries.GetAllCourses;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var response = await _mediator.Send(new GetAllCoursesQueryRequest());

        return Ok(response);
    }
}
