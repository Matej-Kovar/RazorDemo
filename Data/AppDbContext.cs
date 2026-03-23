using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RazorPages25P3A.Models;

namespace RazorPages25P3A.Data
{
    public class AppDbContext : IdentityDbContext<LargerUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            // Suppress the warning caused by the dynamic PasswordHash generation
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            var hasher = new PasswordHasher<LargerUser>();
            var admin = new LargerUser
            {
                Id = "1",
                Email = "a@b.c",
                NormalizedEmail = "A@B.C",
                UserName = "a@b.c",
                NormalizedUserName = "A@B.C",
                EmailConfirmed = true,
                
                PasswordHash = hasher.HashPassword(new LargerUser(), "123456"),
                SecurityStamp = "f3a10c88-5675-4863-8baa-5d90fe9b2828"
            };
            modelBuilder.Entity<LargerUser>().HasData(admin);
        }
    }
}
