using SofiaTeachersOnline.Api.Controllers.Abstracts;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Api.Controllers
{
    public class ExerciseController : BaseEntityController<Exercise, ExerciseDTO>
    {
        public ExerciseController(IEntityService<Exercise, ExerciseDTO> entityService)
            : base(entityService)
        {
        }
    }
}
