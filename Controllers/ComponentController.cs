using Microsoft.AspNetCore.Mvc;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Services.Interfaces;

namespace MicroelectronicsWarehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentsController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentsController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var components = await _componentService.GetAllAsync();
            return Ok(components);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var component = await _componentService.GetByIdAsync(id);
            if (component == null) return NotFound();
            return Ok(component);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComponentDto dto)
        {
            await _componentService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComponentDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var existing = await _componentService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _componentService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _componentService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _componentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
