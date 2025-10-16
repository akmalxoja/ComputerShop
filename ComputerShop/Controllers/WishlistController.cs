using ComputerShop.Data;
using ComputerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly AppDbContext _context;
        public WishlistController(AppDbContext context) => _context = context;

        [HttpGet("{userEmail}")]
        public IActionResult GetWishlist(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
                return Unauthorized("Avval tizimga kiring!");

            var wishlist = _context.Wishlists.Where(w => w.UserId == user.Id).ToList();
            return Ok(wishlist);
        }

        [HttpPost("add")]
        public IActionResult AddToWishlist([FromBody] Wishlist wishlist)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == wishlist.UserId);
            if (user == null)
                return Unauthorized("Avval tizimga kiring!");

            _context.Wishlists.Add(wishlist);
            _context.SaveChanges();
            return Ok(new { message = "Mahsulot wishlistga qo‘shildi!" });
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFromWishlist(int id)
        {
            var item = _context.Wishlists.Find(id);
            if (item == null)
                return NotFound();

            _context.Wishlists.Remove(item);
            _context.SaveChanges();
            return Ok(new { message = "Mahsulot o‘chirildi!" });
        }
    }
}
