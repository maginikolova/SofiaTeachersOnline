using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class CourseMapperConfig : Profile
    {
        public CourseMapperConfig()
        {
            this.CreateMap<Course, CourseDTO>()
                .IncludeAllDerived();               // TODO: Does this even work?
            this.CreateMap<CourseDTO, Course>();    // TODO: Find out why .ReverseMap() is bad

        }
    }
}
