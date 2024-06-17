using Actions.Models;
using Actions.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actions.Handlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionsController : ControllerBase
    {
        private readonly IActionService _actionService;

        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actions.Models.Action>>> GetAll()
        {
            var actions = await _actionService.GetAll();
            return Ok(actions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actions.Models.Action>> GetById(string id)
        {
            var action = await _actionService.GetById(id);
            if (action == null)
            {
                return NotFound();
            }
            return Ok(action);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Actions.Models.Action action)
        {
            if (action == null)
            {
                return BadRequest();
            }

            // Ensure Id is null for new actions
            action.Id = null;

            await _actionService.Create(action);
            return CreatedAtAction(nameof(GetById), new { id = action.Id }, action);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, Actions.Models.Action action)
        {
            if (id != action.Id)
            {
                return BadRequest();
            }

            var existingAction = await _actionService.GetById(id);
            if (existingAction == null)
            {
                return NotFound();
            }

            await _actionService.Update(id, action);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existingAction = await _actionService.GetById(id);
            if (existingAction == null)
            {
                return NotFound();
            }

            await _actionService.Delete(id);
            return NoContent();
        }
    }
}
