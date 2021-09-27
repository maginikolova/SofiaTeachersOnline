using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class GradeMapperConfig : Profile
    {
        public GradeMapperConfig()
        {
            this.CreateMap<Grade, GradeDTO>();
            this.CreateMap<GradeDTO, Grade>();
        }
    }
}
