using ComputerShop.Data;
using ComputerShop.DTOs.AuthDTO;
using ComputerShop.Models.ComputerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }


        // POST: api/Auth/register
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Bu email allaqachon mavjud!");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "Ro‘yxatdan o‘tish muvaffaqiyatli!" });
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            // Admin uchun statik login
            if (dto.Email == "admin@shop.com" && dto.Password == "Admin123")
            {
                return Ok(new
                {
                    role = "Admin",
                    token = "admin-token-123",
                    message = "Admin sifatida tizimga kirdingiz"
                });
            }

            var passwordHash = HashPassword(dto.Password);
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email && u.PasswordHash == passwordHash);

            if (user == null)
                return Unauthorized("Email yoki parol noto‘g‘ri!");

            return Ok(new
            {
                role = user.Role,
                token = "user-token-" + Guid.NewGuid(),
                message = "Tizimga kirish muvaffaqiyatli!"
            });
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
