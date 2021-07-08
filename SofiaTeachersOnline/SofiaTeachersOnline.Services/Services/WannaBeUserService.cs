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
            this.sofiaTeachersOnlineDBContext = sofiaTeachersOnlineDBContext;   //TODO: Add validation if null
        }

        public async Task CreateWannaBeUser(WannaBeUser wannaBeUser)
        {
            if (wannaBeUser == null)
            {
                throw new ArgumentNullException(/*string.Join(ExceptionMessages.InvalidEntry, nameof(WannaBeUser))*/);  // TODO: Add ex. msg
            }

            await this.sofiaTeachersOnlineDBContext.WannaBeUsers.AddAsync(wannaBeUser);
            await this.sofiaTeachersOnlineDBContext.SaveChangesAsync();
        }
    }
}
