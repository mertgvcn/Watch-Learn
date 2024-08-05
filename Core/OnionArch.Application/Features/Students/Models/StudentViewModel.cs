﻿using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Students.Models;
public record StudentViewModel
{
    public long Id { get; init; }
    public UserDTO User { get; set; } = default!;
    public ICollection<CourseDTO> Courses { get; set; } = default!;
}
