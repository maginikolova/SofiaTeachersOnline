using SofiaTeachersOnline.Api.Controllers.Abstracts;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Api.Controllers
{
    public class VideoController : BaseEntityController<Video, VideoDTO>
    {
        public VideoController(IEntityService<Video, VideoDTO> gradeService)
            : base(gradeService)
        {
        }
    }
}
