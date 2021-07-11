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

        public Task<TEntity> CreateEntityAsync(TEntity entityDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEntityAsync(int id)
        {
            // TODO: Add validation for entityId

            var entity = await this._dbContext.FindAsync<TEntity>(id);

            if (entity == null)
            {
                throw new ArgumentException(string.Format(SofiaTeachersOnlineConstants.ExceptionMessages.EntityNotFound, typeof(TEntity).Name, id));
            }

            entity.DeletedOn = DateTime.Now;
            entity.IsDeleted = true;
            // TODO: Should we add DeletedBy?

            await this._dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAllEntities()
            => this._dbContext.Set<TEntity>().AsQueryable();

        public async Task<TEntity> GetEntityByIdAsync(int id)
            => await this._dbContext.FindAsync<TEntity>(id);    // TODO: Will it be able to Include?

        public Task<TEntity> PatchEntityAsync(int id)
        {
            // TODO: Add validation for entityId

            throw new NotImplementedException();
        }
    }
}
