using AutoMapper;
using OnionArch.Application.Features.Courses.Models.Views;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper.Resolvers;
public class StudentProgressResolver : IValueResolver<Course, CurrentStudentCourseViewModel, short>
{
	private readonly IHttpContextService _httpContextService;

	public StudentProgressResolver(IHttpContextService httpContextService)
	{
		_httpContextService = httpContextService;
	}

	public short Resolve(Course source, CurrentStudentCourseViewModel destination, short destMember, ResolutionContext context)
	{
		var userId = _httpContextService.GetCurrentUserId();

		var completedLessonsCount = source.Lessons
			.SelectMany(l => l.StudentLessonProgresses)
			.Count(slp => slp.StudentId == userId && slp.IsCompleted);

		var totalLessonsCount = source.Lessons.Count;

		return totalLessonsCount == 0 ? (short)0 : (short)((completedLessonsCount * 100) / totalLessonsCount);
	}
}