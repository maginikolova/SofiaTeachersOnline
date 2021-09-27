using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class ExerciseMapperConfig : Profile
    {
        public ExerciseMapperConfig()
        {
            this.CreateMap<Exercise, ExerciseDTO>();
            this.CreateMap<ExerciseDTO, Exercise>();
        }
    }
}
