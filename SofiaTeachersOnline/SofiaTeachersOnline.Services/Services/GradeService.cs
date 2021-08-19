using Microsoft.AspNetCore.Identity;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    public class GradeService : EntityService<Grade, GradeDTO>
    {
        public GradeService(SofiaTeachersOnlineDbContext dbContext/*, UserManager<AppUser> userManager, IMapper mapper*/)
            : base(dbContext/*, userManager*/)
        {
        }
    }
}