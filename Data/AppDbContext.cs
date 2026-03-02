using Microsoft.EntityFrameworkCore;
using RazorPages25P3A.Models;

namespace RazorPages25P3A.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<FormModel> FormModels { get; set; } = null!;

        // You can configure model details here if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FormModel>(entity =>
            {
                entity.HasKey(e => e.FormModelId);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });
        }
    }
}
