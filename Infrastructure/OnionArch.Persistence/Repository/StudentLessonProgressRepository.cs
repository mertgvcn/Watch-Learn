using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public sealed class StudentLessonProgressRepository(AppDbContext context)
	: BaseRepository<StudentLessonProgress>(context), IStudentLessonProgressRepository
{
	public async Task<StudentLessonProgress> GetByStudentAndLessonIds(long studentId, long lessonId, CancellationToken cancellationToken)
	{
		return await GetAll().Where(a => a.StudentId == studentId && a.LessonId == lessonId).SingleAsync(cancellationToken);
	}
}
