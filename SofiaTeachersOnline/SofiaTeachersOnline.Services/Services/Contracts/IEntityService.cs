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
        Task<TEntityDTO> CreateEntityAsync(TEntityDTO entityDTO);
        IQueryable<TEntityDTO> GetAllEntities();
        Task<TEntityDTO> GetEntityByIdAsync(int entityId);
        Task<TEntityDTO> UpdateEntityAsync(int id, TEntityDTO entityDTO, ClaimsPrincipal User);
        Task DeleteEntityAsync(int entityId);
        
        //Task<TEntity> PatchEntityAsync(int entityId, JsonPatchDocument<TEntity> entityPatch);
    }
}
