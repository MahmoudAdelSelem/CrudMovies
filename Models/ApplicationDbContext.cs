using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreCrudeMovies.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasKey(n => n.id);
            modelBuilder.Entity<Genre>().Property(n => n.id).ValueGeneratedOnAdd().HasColumnType("TINYINT");

            modelBuilder.Entity<Genre>().Property(n => n.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Genre>().HasMany<Movie>(g => g.Movies)
                .WithOne(s => s.Genre)
                .HasForeignKey(s => s.GenreId);
            modelBuilder.Entity<Movie>().HasKey(n => n.id);
            modelBuilder.Entity<Movie>().Property(n => n.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Movie>().Property(n => n.Year).IsRequired();
            modelBuilder.Entity<Movie>().Property(n => n.GenreId).HasColumnType("TINYINT");
            modelBuilder.Entity<Movie>().Property(n => n.Title).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Movie>().Property(n => n.StoryLine).HasMaxLength(2500);
            modelBuilder.Entity<Movie>().Property(n => n.Poster).HasMaxLength(2500);
            modelBuilder.Entity<Movie>().Property(n => n.Rate).IsRequired(false);


        }
    }
}
