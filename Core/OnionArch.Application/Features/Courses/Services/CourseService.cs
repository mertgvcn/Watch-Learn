﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Courses;
using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Courses.Services;
public sealed class CourseService : ICourseService
{
	private readonly ICourseRepository _courseRepository;
	private readonly IStudentRepository _studentRepository;
	private readonly IStudentLessonProgressRepository _studentLessonProgressRepository;
	private readonly IHttpContextService _httpContextService;
	private readonly ITransactionService _transactionService;
	private readonly IMapper _mapper;

	public CourseService(
		ICourseRepository courseRepository,
		IStudentRepository studentRepository,
		IStudentLessonProgressRepository studentLessonProgressRepository,
		IHttpContextService httpContextService,
		ITransactionService transactionService,
		IMapper mapper
		)
	{
		_courseRepository = courseRepository;
		_studentRepository = studentRepository;
		_studentLessonProgressRepository = studentLessonProgressRepository;
		_httpContextService = httpContextService;
		_transactionService = transactionService;
		_mapper = mapper;
	}

	public async Task<List<CourseViewModel>> GetAllCoursesAsync(CancellationToken cancellationToken)
	{

		var courses = await _courseRepository.GetAll()
			.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		return courses;
	}

	public async Task<CourseViewModel> GetCourseByIdAsync(long id, CancellationToken cancellationToken)
	{
		var course = await _courseRepository.GetById(id)
			.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
			.SingleOrDefaultAsync(cancellationToken);

		if (course == null)
			throw new CourseNotFoundException($"Course with Id {id} returned null.");

		return course;
	}

	public async Task<List<MyCourseViewModel>> GetMyCourses(CancellationToken cancellationToken)
	{
		var userId = _httpContextService.GetCurrentUserId();
		var courses = await _courseRepository.GetStudentCoursesByUserId(userId)
			.ProjectTo<MyCourseViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

		return courses;
	}

	public async Task EnrollCurrentUserInCourseAsync(EnrollCurrentUserInCourseRequest request, CancellationToken cancellationToken)
	{
		var userId = _httpContextService.GetCurrentUserId();
		var student = await _studentRepository.GetByUserIdAsync(userId, cancellationToken);

		var course = await _courseRepository.GetById(request.CourseId).Include(x => x.Students).SingleOrDefaultAsync(cancellationToken);
		if (course == null)
			throw new CourseNotFoundException($"Course with id {request.CourseId} returned null");

		using var transaction = await _transactionService.CreateTransactionAsync(cancellationToken);

		course.Students.Add(student);
		await _courseRepository.UpdateAsync(course);
		await EnrollStudentInLessonsAsync(student.Id, course.Lessons, cancellationToken);

		await transaction.CommitAsync(cancellationToken);
	}

	public async Task AddCourseAsync(AddCourseRequest request, CancellationToken cancellationToken)
	{
		var newCourse = _mapper.Map<Course>(request);

		await _courseRepository.AddAsync(newCourse, cancellationToken);
	}

	public async Task UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken)
	{
		var existingCourse = await _courseRepository.GetByIdAsync(request.Id);

		if (existingCourse == null)
			throw new CourseNotFoundException($"Course with Id {request.Id} returned null.");

		_mapper.Map(request, existingCourse);
		await _courseRepository.UpdateAsync(existingCourse, cancellationToken);
	}
	private async Task EnrollStudentInLessonsAsync(long studentId, IEnumerable<Lesson> lessons, CancellationToken cancellationToken)
	{
		var studentLessonProgresses = lessons.Select(lesson => new StudentLessonProgress
		{
			StudentId = studentId,
			LessonId = lesson.Id
		});

		await _studentLessonProgressRepository.AddRangeAsync(studentLessonProgresses, cancellationToken);
	}
}
