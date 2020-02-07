﻿using AllNotes.Domain.Dtos;
using AllNotes.Domain.Models;
using AllNotes.Domain.Models.Memo;
using AllNotes.Domain.Models.Sport;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotes.WebApi.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Schedule, ScheduleDto>().ReverseMap();
            CreateMap<CheckList, CheckListDto>().ReverseMap();
            CreateMap<CheckBox, CheckBoxDto>().ReverseMap();
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Series, SeriesDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            
        }
    }
}
