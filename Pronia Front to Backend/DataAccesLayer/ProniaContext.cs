using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pronia_Front_to_Backend.Models;

namespace Pronia_Front_to_Backend.DataAccesLayer
{
    public class ProniaContext : IdentityDbContext
    {
        public ProniaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; init; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LAPTOP-IM3K1CPI\\SQLEXPRESS;DataBase=ProniaTask;Trusted_Connection=true;TrustServerCertificate = True");
            base.OnConfiguring(options);
        }
    }
}
