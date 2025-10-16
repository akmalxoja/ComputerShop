using ComputerShop.DTOs.Computer;
using ComputerShop.Models;
using ComputerShop.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        // GET: api/computer
        [HttpGet]
        public async Task<ActionResult<List<Computer>>> GetAll()
        {
            var computers = await _computerService.GetAllAsync();
            return Ok(computers);
        }

        // GET: api/computer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetById(int id)
        {
            var computer = await _computerService.GetByIdAsync(id);
            if (computer == null)
                return NotFound();

            return Ok(computer);
        }

        // POST: api/computer
        [HttpPost]
        public async Task<ActionResult<Computer>> Create([FromBody] ComputerCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _computerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/computer/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Computer>> Update(int id, [FromBody] ComputerUpdateDto dto)
        {
            var updated = await _computerService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/computer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _computerService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        // GET: api/computer/filter
        [HttpGet("filter")]
        public async Task<ActionResult<List<Computer>>> Filter([FromQuery] ComputerFilterDto filterDto)
        {
            var result = await _computerService.FilterAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("gpus")]
        public async Task<IActionResult> GetGpus()
        {
            var gpus = await _computerService.GetAvailableGpusAsync();
            return Ok(gpus);
        }

        [HttpGet("cpus")]
        public async Task<IActionResult> GetCpus()
        {
            var cpus = await _computerService.GetAvailableCpusAsync();
            return Ok(cpus);

        }

        //Serch
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var result = _computerService.SearchComputers(keyword);
            return Ok(result);
        }

    }
}
