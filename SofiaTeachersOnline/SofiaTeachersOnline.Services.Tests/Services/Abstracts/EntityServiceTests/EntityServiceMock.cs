using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Abstracts;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.EntityServiceTests
{
    public class EntityServiceMock : BaseEntityService<Grade, GradeDTO>
    {
        public EntityServiceMock(SofiaTeachersOnlineDbContext dbContext/*, IMapper mapper*/)
            : base(dbContext)
        {
        }
    }
}
