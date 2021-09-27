using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class CourseProgressMapperConfig : Profile
    {
        public CourseProgressMapperConfig()
        {
            this.CreateMap<CourseProgress, CourseProgressDTO>();
            this.CreateMap<CourseProgressDTO, CourseProgress>();
        }
    }
}
