using Backend_Development_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


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

    }
}
