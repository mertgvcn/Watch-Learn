﻿namespace OnionArch.Application.Features.Courses.Models.Parameters;
public record UpdateCourseRequest
{
	public required long Id { get; init; }
	public string Title { get; set; } = default!;
	public string ShortDescription { get; set; } = default!;
	public string Description { get; set; } = default!;
	public double Price { get; set; } = default!;
	public long TeacherId { get; set; }
}
