using SofiaTeachersOnline.Api.Controllers.Abstracts;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Api.Controllers
{
    public class CourseController : BaseEntityController<Course, CourseDTO>
    {
        public CourseController(IEntityService<Course, CourseDTO> entityService)
            : base(entityService)
        {
        }
    }
}
