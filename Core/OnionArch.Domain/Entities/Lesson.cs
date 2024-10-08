﻿using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Lesson : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
	public string? EditedBy { get; set; }
	public DateTime? DateModified { get; set; }
	public bool IsDeleted { get; set; }
	public required short LessonNumber { get; set; }
	public required string Title { get; set; }
	public required string Description { get; set; }
	public required string VideoUrl { get; set; }
	public required int DurationInSeconds { get; set; }
	public long CourseId { get; set; }
	public ICollection<StudentLessonProgress> StudentLessonProgresses { get; set; } = default!;
}
