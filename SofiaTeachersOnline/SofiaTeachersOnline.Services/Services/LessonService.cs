using AutoMapper;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    public class LessonService : BaseEntityService<Lesson, LessonDTO>
    {
        public LessonService(SofiaTeachersOnlineDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }
    }
}
