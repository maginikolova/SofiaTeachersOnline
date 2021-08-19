using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using SofiaTeachersOnline.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Api.Controllers.Abstracts
{
    // TODO: TEST THIS REEEEALLY CAREFULLY!!
    // TODO: Maybe separate it into ModifiableEntityControler, which inherits EntityController, but has UpdateEntity()
    [ApiController] // TODO: Find out how to add [ApiController] to the whole assembly?
    [Route("[controller]")]
    public abstract class EntityController<TEntity, TEntityDTO> : ControllerBase
        where TEntity : Entity, IModifiable  // TODO: Will it work with AppUser?
        where TEntityDTO : class
    {
        private readonly IEntityService<TEntity, TEntityDTO> _entityService;

        public EntityController(IEntityService<TEntity, TEntityDTO> entityService)
        {
            this._entityService = entityService ?? throw new ArgumentNullException(nameof(entityService));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TEntity entityDTO)   // TODO: Or should it be named Post?     // TODO: Doesn't need [FromBody]?
        {
            var result = await _entityService.CreateEntityAsync(entityDTO);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _entityService.GetAllEntities();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _entityService.GetEntityByIdAsync(id);

            return Ok(result);  // TODO: How to make it return NotFound?
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TEntity entityDTO)     // TODO: Or should it be named Put?     // TODO: Doesn't need [FromBody]?
        {
            entityDTO.Id = id;  // TODO: Move to the services
            var entity = await _entityService.UpdateEntityAsync(id, entityDTO, this.User);

            return Ok(entity);    // Should it return an entity?
        }

        // JSON body is empty
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Grade> entityPatch)
        //{
        //    await _gradeService.PatchEntityAsync(id, entityPatch);
        //
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteEntityAsync(id);

            return Ok();
        }
    }
}
