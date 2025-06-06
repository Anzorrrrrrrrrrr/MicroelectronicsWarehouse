using Microsoft.AspNetCore.Mvc;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Services.Interfaces;

namespace MicroelectronicsWarehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto dto)
        {
            await _categoryService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var existing = await _categoryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _categoryService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _categoryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
