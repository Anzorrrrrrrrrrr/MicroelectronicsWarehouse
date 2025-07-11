﻿using Microsoft.AspNetCore.Mvc;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MicroelectronicsWarehouse.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("error-test")]
        public IActionResult ThrowError()
        {
            throw new Exception("Тестова помилка");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] RequestParams requestParams)
        {
            var result = await _categoryService.GetAllAsync(requestParams);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Create([FromBody] CategoryDto dto)
        {
            await _categoryService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        [Authorize] 
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var existing = await _categoryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _categoryService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize] 
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _categoryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
