using Microsoft.AspNetCore.Mvc;
using Profile.Models;
using Profile.Services;

namespace Profile.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await _profileService.GetAllAsync();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var profile = await _profileService.GetByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserProfile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }

            profile.Id = null; // Ensure the ID is not provided by the client
            await _profileService.CreateAsync(profile);
            return CreatedAtAction(nameof(GetById), new { id = profile.Id }, profile);
        }
    }
}
