using Microsoft.EntityFrameworkCore;
using ChurchAppBibleAPI.Models;

namespace ChurchAppBibleAPI.Data
{
    public class BibleContext : DbContext
    {
        public BibleContext(DbContextOptions<BibleContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Verse> Verses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  // Fixed capitalization here
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Chapter>().ToTable("Chapters");
            modelBuilder.Entity<Verse>().ToTable("Verses");
        }
    }
}