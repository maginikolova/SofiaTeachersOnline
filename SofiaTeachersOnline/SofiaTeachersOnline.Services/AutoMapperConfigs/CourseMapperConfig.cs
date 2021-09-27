using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class CourseMapperConfig : Profile
    {
        public CourseMapperConfig()
        {
            this.CreateMap<Course, CourseDTO>();  // TODO: Find out why .ReverseMap() is bad
            this.CreateMap<CourseDTO, Course>();
        }
    }
}
