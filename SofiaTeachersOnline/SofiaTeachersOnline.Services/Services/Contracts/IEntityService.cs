using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Contracts
{
    public interface IEntityService<TEntity, TEntityDTO>
        where TEntity : Entity, IModifiable
        where TEntityDTO : class
    {
        Task<TEntity> CreateEntityAsync(TEntity entityDTO);
        IQueryable<TEntity> GetAllEntities();
        Task<TEntity> GetEntityByIdAsync(int entityId);
        Task<TEntity> UpdateEntityAsync(int id, TEntity entityDTO, ClaimsPrincipal User);
        Task DeleteEntityAsync(int entityId);
        
        //Task<TEntity> PatchEntityAsync(int entityId, JsonPatchDocument<TEntity> entityPatch);
    }
}
