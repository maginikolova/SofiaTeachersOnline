using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    // TODO: CoureService
    public class CourseService : BaseEntityService<Course, CourseDTO>
    {
        public CourseService(SofiaTeachersOnlineDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
