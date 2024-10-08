﻿using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Application.Features.Lessons.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapper;
public class LessonProfile : Profile
{
	public LessonProfile()
	{
		CreateMap<Lesson, LessonViewModel>();
		CreateMap<Lesson, LessonDTO>();
		CreateMap<AddLessonRequest, Lesson>();
		CreateMap<UpdateLessonRequest, Lesson>();
	}
}
