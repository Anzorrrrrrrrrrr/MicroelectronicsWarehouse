using Microsoft.AspNetCore.Mvc;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Services.Interfaces;

namespace MicroelectronicsWarehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAllAsync();
            return Ok(suppliers); // 200 OK
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier == null)
                return NotFound(); // 404
            return Ok(supplier); // 200
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierDto dto)
        {
            await _supplierService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto); // 201 Created
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierDto dto)
        {
            if (id != dto.Id)
                return BadRequest(); // 400

            var existing = await _supplierService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(); // 404

            await _supplierService.UpdateAsync(dto);
            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _supplierService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(); // 404

            await _supplierService.DeleteAsync(id);
            return NoContent(); // 204
        }
    }
}
