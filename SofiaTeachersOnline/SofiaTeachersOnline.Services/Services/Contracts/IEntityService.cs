using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Contracts
{
    public interface IEntityService<TEntity, TEntityDTO>
    {
        Task<TEntity> CreateEntityAsync(TEntity entityDTO);
        IQueryable<TEntity> GetAllEntities();
        Task<TEntity> GetEntityByIdAsync(int entityId);
        Task<TEntity> PatchEntityAsync(int entityId);
        Task DeleteEntityAsync(int entityId);
    }
}
