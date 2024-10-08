﻿using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface ILessonRepository : IBaseRepository<Lesson>
{
    IQueryable<Lesson> GetAllByCourseId(long courseId);
}
