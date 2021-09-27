using AutoMapper;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    // TODO: Exercise service
    public class ExerciseService : BaseEntityService<Exercise, ExerciseDTO>
    {
        public ExerciseService(SofiaTeachersOnlineDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }
    }
}
