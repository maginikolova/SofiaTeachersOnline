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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gradeService.DeleteEntityAsync(id);

            return Ok();
        }
    }
}
