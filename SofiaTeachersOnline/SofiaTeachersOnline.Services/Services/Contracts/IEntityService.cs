using SofiaTeachersOnline.Database.Models.Abstracts;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Contracts
{
    public interface IEntityService<TEntity, TEntityDTO>
        where TEntity : Entity
        where TEntityDTO : class
    {
        Task<TEntity> CreateEntityAsync(TEntity entityDTO);
        IQueryable<TEntity> GetAllEntities();
        Task<TEntity> GetEntityByIdAsync(int entityId);
        Task<TEntity> UpdateEntityAsync(int id, TEntity entityDTO);
        Task DeleteEntityAsync(int entityId);
        
        //Task<TEntity> PatchEntityAsync(int entityId, JsonPatchDocument<TEntity> entityPatch);
    }
}
