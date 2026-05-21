using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}