using ComputerShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options) { }


        public DbSet<Computer> Computers { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Qo‘shimcha konfiguratsiyalar kerak bo‘lsa shu yerda yoziladi
            // Masalan: unique constraint
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


    }
}
