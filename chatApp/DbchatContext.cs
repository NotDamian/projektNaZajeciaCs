using chatApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace chatApp
{
    public class DbchatContext : IdentityDbContext<UserModel>
    {
       public DbchatContext(DbContextOptions<DbchatContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-316ND0U\\SQLEXPRESS;Database=Product;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
