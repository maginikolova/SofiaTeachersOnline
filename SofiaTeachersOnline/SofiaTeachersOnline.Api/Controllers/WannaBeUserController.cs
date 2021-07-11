using Microsoft.AspNetCore.Mvc;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Api.Controllers
{
    [ApiController] // TODO: Find out how to add [ApiController] to the whole assembly?
    [Route("[controller]")]
    public class WannaBeUserController : ControllerBase
    {
        private readonly IWannaBeUserService wannaBeUserService;

        public WannaBeUserController(IWannaBeUserService wannaBeUserService)
        {
            this.wannaBeUserService = wannaBeUserService ?? throw new ArgumentNullException(nameof(wannaBeUserService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WannaBeUser wannaBeUser)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid wannabeuser.");
            }

            try
            {
                await this.wannaBeUserService.CreateWannaBeUser(wannaBeUser);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
