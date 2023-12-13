using Domain.Models.Animals.Dogs;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SMARTFRIDGE; Database=RealDB; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
