using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class LessonMapperConfig : Profile
    {
        public LessonMapperConfig()
        {
            this.CreateMap<Lesson, LessonDTO>();
            this.CreateMap<LessonDTO, Lesson>();
        }
    }
}
