using ComputerShop.Data;
using ComputerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context) => _context = context;

        // GET api/cart/{userEmail}
        [HttpGet("{userEmail}")]
        public IActionResult GetUserCart(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
                return Unauthorized("Avval tizimga kiring!");

            var cartItems = _context.Carts.Where(c => c.UserId == user.Id).ToList();
            return Ok(cartItems);
        }

        // POST api/cart/add
        [HttpPost("add")]
        public IActionResult AddToCart([FromBody] Cart cart)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == cart.UserId);
            if (user == null)
                return Unauthorized("Avval tizimga kiring!");

            _context.Carts.Add(cart);
            _context.SaveChanges();
            return Ok(new { message = "Mahsulot savatga qo‘shildi!" });
        }

        // DELETE api/cart/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            var item = _context.Carts.Find(id);
            if (item == null)
                return NotFound();

            _context.Carts.Remove(item);
            _context.SaveChanges();
            return Ok(new { message = "Mahsulot o‘chirildi!" });
        }
    }
}
