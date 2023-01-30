using Backend_Development_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend_Development_Assignment_3.Data
{
    public class DataStoreDbContext : DbContext
    {
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Character>? Characters { get; set; }
        public DbSet<Franchise>? Franchises { get; set; }
        public DataStoreDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(DataSeeder.GetMovies());
            modelBuilder.Entity<Character>().HasData(DataSeeder.GetCharacters());
            modelBuilder.Entity<Franchise>().HasData(DataSeeder.GetFranchises());
            modelBuilder.Entity("CharacterMovie").HasData(DataSeeder.SetRelationships());
        }
    }
}
