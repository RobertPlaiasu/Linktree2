using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication1.Entites;

namespace WebApplication1.Data
{
    public class LinktreeDbContext : DbContext
    {
        public LinktreeDbContext(DbContextOptions<LinktreeDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
                

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Bob",
                Email = "bob@bob.com",
                Password = "password"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Sarah",
                Email = "sarah@sarah.com",
                Password = "password"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                Id = 1,
                UserId = 1,
                Url = "https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?source=recommendations&tabs=vs",
                PlatformId = Enums.Platform.Github
            });


        }
    }
}
