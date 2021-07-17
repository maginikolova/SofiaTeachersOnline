using Microsoft.AspNetCore.Mvc;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Api.Controllers
{
    [ApiController] // TODO: Find out how to add [ApiController] to the whole assembly?
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IEntityService<Grade, GradeDTO> _gradeService;

        public GradeController(IEntityService<Grade, GradeDTO> gradeService)
        {
            this._gradeService = gradeService ?? throw new ArgumentNullException(nameof(gradeService));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Grade entityDTO)   // TODO: Or should it be named Post?     // TODO: Doesn't need [FromBody]?
        {
            var result = await _gradeService.CreateEntityAsync(entityDTO);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _gradeService.GetAllEntities();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _gradeService.GetEntityByIdAsync(id);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Grade entityDTO)     // TODO: Or should it be named Put?     // TODO: Doesn't need [FromBody]?
        {
            entityDTO.Id = id;  // TODO: Move to the services
            var entity = await _gradeService.UpdateEntityAsync(id, entityDTO);

            return Ok(entity);    // Should it return an entity?
        }

/*      // JSON body is empty
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Grade> entityPatch)
        {
            await _gradeService.PatchEntityAsync(id, entityPatch);

            return Ok();
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gradeService.DeleteEntityAsync(id);

            return Ok();
        }
    }
}
