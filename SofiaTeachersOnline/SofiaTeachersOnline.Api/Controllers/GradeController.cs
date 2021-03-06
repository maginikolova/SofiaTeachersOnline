using SofiaTeachersOnline.Api.Controllers.Abstracts;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Api.Controllers
{
    public class GradeController : BaseEntityController<Grade, GradeDTO>
    {
        public GradeController(IEntityService<Grade, GradeDTO> gradeService)
            : base(gradeService)
        {
        }
    }
}
