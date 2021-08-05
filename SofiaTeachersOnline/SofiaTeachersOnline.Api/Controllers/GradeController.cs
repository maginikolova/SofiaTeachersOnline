using Microsoft.AspNetCore.Mvc;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Api.Controllers
{
    [ApiController] // TODO: Find out how to add [ApiController] to the whole assembly?
    [Route("[controller]")]
    public class GradeController : EntityController<Grade, GradeDTO>
    {
        public GradeController(IEntityService<Grade, GradeDTO> gradeService)
            : base(gradeService)
        {
        }
    }
}
