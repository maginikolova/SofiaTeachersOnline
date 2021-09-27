using AutoMapper;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Services
{
    public class GradeService : BaseEntityService<Grade, GradeDTO>
    {
        public GradeService(SofiaTeachersOnlineDbContext dbContext, IMapper mapper/*, UserManager<AppUser> userManager, IMapper mapper*/)
            : base(dbContext, mapper/*, userManager*/)
        {
        }
    }
}