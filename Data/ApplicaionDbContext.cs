using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualGallery.Models;

namespace VirtualGallery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .ToTable("Images")
                .HasOne(i => i.Author)  
                .WithMany()  
                .HasForeignKey(i => i.ID);  

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Category)  
                .WithMany(c => c.Images) 
                .HasForeignKey(i => i.ID); 

            modelBuilder.Entity<Category>()
                .ToTable("Categories")
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .ToTable("Authors")
                .Property(a => a.Name)
                .IsRequired();
        }
    }
}
