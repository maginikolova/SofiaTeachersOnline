using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    public class VideoService : BaseEntityService<Video, VideoDTO>
    {
        public VideoService(SofiaTeachersOnlineDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
