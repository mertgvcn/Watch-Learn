﻿namespace OnionArch.Application.DTOs;
public record TeacherDTO
{
    public required long Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
