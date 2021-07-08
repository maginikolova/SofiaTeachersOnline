using SofiaTeachersOnline.Database.Models;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Contracts
{
    public interface IWannaBeUserService
    {
        Task CreateWannaBeUser(WannaBeUser wannaBeUser);
    }
}
