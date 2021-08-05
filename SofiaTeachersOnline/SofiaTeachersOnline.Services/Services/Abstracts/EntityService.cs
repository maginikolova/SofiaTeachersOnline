using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Services.Services.Contracts;
using SofiaTeachersOnline.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Abstracts
{
    public abstract class EntityService<TEntity, TEntityDTO> : IEntityService<TEntity, TEntityDTO>
        where TEntity : Entity
        where TEntityDTO : class
    {
        //private readonly IMapper _mapper;
        protected SofiaTeachersOnlineDbContext _dbContext;

        protected EntityService(SofiaTeachersOnlineDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entityDTO)
        {
            this._dbContext.Add(entityDTO);

            await this._dbContext.SaveChangesAsync();

                return entityDTO;   // Should we return the DTO or the real entity from the DB?
        }

        public IQueryable<TEntity> GetAllEntities()
            => this._dbContext.Set<TEntity>().AsQueryable();

        public async Task<TEntity> GetEntityByIdAsync(int id)
            => await this._dbContext.FindAsync<TEntity>(id);    // TODO: Will it be able to Include?

        public async Task<TEntity> UpdateEntityAsync(int id, TEntity entityDTO)
        {
            var entity = await this._dbContext.FindAsync<TEntity>(id);

            if (entity == null)
            {
                throw new ArgumentException(string.Format(SofiaTeachersOnlineConstants.ExceptionMessages.EntityNotFound, typeof(TEntity).Name, id));
                // TODO: Better error hanling!
            }

            //_dbContext.Entry(entity).State = EntityState.Detached;
            //var updatedEntity = this._dbContext.Update(entityDTO);    // TODO: Which PUT method is better?

            this._dbContext.Entry(entity).CurrentValues.SetValues(entityDTO);
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
