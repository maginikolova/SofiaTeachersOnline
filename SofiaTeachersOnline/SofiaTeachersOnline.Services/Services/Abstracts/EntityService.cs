using Microsoft.AspNetCore.Identity;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using SofiaTeachersOnline.Services.Services.Contracts;
using SofiaTeachersOnline.Shared;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Abstracts
{
    // TODO: Maybe separate it into ModifiableEntityService, which inherits EntityService, but has UpdateEntity()
    public abstract class EntityService<TEntity, TEntityDTO> : IEntityService<TEntity, TEntityDTO>
        where TEntity : Entity, IModifiable
        where TEntityDTO : class
    {
        //private readonly IMapper _mapper;
        protected SofiaTeachersOnlineDbContext _dbContext;
        //private readonly UserManager<AppUser> _userManager;

        protected EntityService(SofiaTeachersOnlineDbContext dbContext/*, UserManager<AppUser> userManager*/)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            //this._userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entityDTO)
        {
            // TODO: Should we validate if entityDTO is null?
            this._dbContext.Add(entityDTO);

            await this._dbContext.SaveChangesAsync();

            return entityDTO;   // Should we return the DTO or the real entity from the DB?
        }

        public IQueryable<TEntity> GetAllEntities()
            => this._dbContext.Set<TEntity>().AsQueryable();

        public async Task<TEntity> GetEntityByIdAsync(int id)
            => await this._dbContext.FindAsync<TEntity>(id);    // TODO: Will it be able to Include?

        public async Task<TEntity> UpdateEntityAsync(int id, TEntity entityDTO, ClaimsPrincipal User)
        {
            // TODO: Chech if User isn't null 

            var entity = await this._dbContext.FindAsync<TEntity>(id);

            if (entity == null)
            {
                throw new ArgumentException(string.Format(SofiaTeachersOnlineConstants.ExceptionMessages.EntityNotFound, typeof(TEntity).Name, id));
                // TODO: Better error hanling!
            }

            //_dbContext.Entry(entity).State = EntityState.Detached;
            //var updatedEntity = this._dbContext.Update(entityDTO);    // TODO: Which PUT method is better?

            this._dbContext.Entry(entity).CurrentValues.SetValues(entityDTO);
            
            //var user = await this._userManager.GetUserAsync(User);
            entity.ModifiedOn = DateTime.Now;
            //entity.ModifiedByUserId = user.Id;

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

/*        public async Task<TEntity> PatchEntityAsync(int id, JsonPatchDocument<TEntity> entityPatch)     // TODO: PATCH NOT WORKING!!!
        {
            // TODO: Add validation for entityId

            var entity = await this._dbContext.FindAsync<TEntity>(id);

            if (entity == null)
            {
                throw new ArgumentException(string.Format(SofiaTeachersOnlineConstants.ExceptionMessages.EntityNotFound, typeof(TEntity).Name, id));
                // TODO: Better error hanling!
            }

            // TODO: Add EditedOn and EditedBy?
            entityPatch.ApplyTo(entity);
            await this._dbContext.SaveChangesAsync();
            return default;
        }*/

        public async Task DeleteEntityAsync(int id)
        {
            // TODO: Add validation for entityId?   

            var entity = await this._dbContext.FindAsync<TEntity>(id);

            if (entity == null)
            {
                throw new ArgumentException(string.Format(SofiaTeachersOnlineConstants.ExceptionMessages.EntityNotFound, typeof(TEntity).Name, id)); 
                // TODO: Better error handling!
            }

            entity.DeletedOn = DateTime.Now;
            entity.IsDeleted = true;
            // TODO: Should we add DeletedBy?

            await this._dbContext.SaveChangesAsync();
        }
    }
}
