using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    public class GradeService : BaseEntityService<Grade, GradeDTO>
    {
        public GradeService(SofiaTeachersOnlineDbContext dbContext/*, UserManager<AppUser> userManager, IMapper mapper*/)
            : base(dbContext/*, userManager*/)
        {
        }
    }
}