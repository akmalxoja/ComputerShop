using ComputerShop.DTOs.Keyboard;
using ComputerShop.Models;
using ComputerShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly IKeyboardService _keyboardService;

        public KeyboardController(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        // ✅ GET: api/keyboard
        [HttpGet]
        public async Task<ActionResult<List<Keyboard>>> GetAll()
        {
            var keyboards = await _keyboardService.GetAllAsync();
            return Ok(keyboards);
        }

        // ✅ GET: api/keyboard/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Keyboard>> GetById(int id)
        {
            var keyboard = await _keyboardService.GetByIdAsync(id);
            if (keyboard == null)
                return NotFound();

            return Ok(keyboard);
        }

        // ✅ POST: api/keyboard
        [HttpPost]
        public async Task<ActionResult<Keyboard>> Create([FromBody] KeyboardCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _keyboardService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ✅ PUT: api/keyboard/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Keyboard>> Update(int id, [FromBody] KeyboardUpdateDto dto)
        {
            var updated = await _keyboardService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // ✅ DELETE: api/keyboard/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _keyboardService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        // ✅ SEARCH: api/keyboard/search?keyword=mechanical
        //[HttpGet("search")]
        //public IActionResult Search([FromQuery] string keyword)
        //{
        //    var result = _keyboardService.SearchKeyboards(keyword);
        //    return Ok(result);
        //}

        // ✅ FILTER: api/keyboard/filter?SwitchType=Mechanical&IsWireless=true&MinPrice=50&MaxPrice=200
        [HttpGet("filter")]
        public async Task<ActionResult<List<Keyboard>>> Filter([FromQuery] KeyboardFilterDto filterDto)
        {
            var filtered = await _keyboardService.FilterAsync(filterDto);
            return Ok(filtered);
        }





        // ✅ DROPDOWN: Switch types ro‘yxatini olish
        [HttpGet("switch-types")]
        public async Task<IActionResult> GetSwitchTypes()
        {
            var types = await _keyboardService.GetAvailableSwitchTypesAsync();
            return Ok(types);
        }

        // ✅ DROPDOWN: Brendlar ro‘yxatini olish
        //[HttpGet("brands")]
        //public async Task<IActionResult> GetBrands()
        //{
        //    var brands = await _keyboardService.GetAvailableBrandsAsync();
        //    return Ok(brands);
        //}

        [HttpGet("wireless-options")]
        public async Task<IActionResult> GetWirelessOptions()
        {
            var options = await _keyboardService.GetAvailableWirelessOptionsAsync();
            return Ok(options);
        }


        //Serch
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var result = _keyboardService.SearchKeyboards(keyword);
            return Ok(result);
        }
    }
}
