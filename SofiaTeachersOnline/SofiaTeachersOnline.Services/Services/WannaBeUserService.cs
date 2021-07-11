using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services
{
    public class WannaBeUserService : IWannaBeUserService
    {
        private readonly SofiaTeachersOnlineDbContext sofiaTeachersOnlineDBContext;

        public WannaBeUserService(SofiaTeachersOnlineDbContext sofiaTeachersOnlineDBContext)
        {
            this.sofiaTeachersOnlineDBContext = sofiaTeachersOnlineDBContext ?? throw new ArgumentNullException(nameof(sofiaTeachersOnlineDBContext));
        }

        public async Task CreateWannaBeUser(WannaBeUser wannaBeUser)
        {
            if (wannaBeUser == null)
            {
                throw new ArgumentNullException(nameof(wannaBeUser));
            }

            await this.sofiaTeachersOnlineDBContext.WannaBeUsers.AddAsync(wannaBeUser);
            await this.sofiaTeachersOnlineDBContext.SaveChangesAsync();
        }
    }
}
