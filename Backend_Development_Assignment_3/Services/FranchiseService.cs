using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.DTOs;
using Backend_Development_Assignment_3.DTOs.CharacterDTOs;
using Backend_Development_Assignment_3.Exceptions;
using Backend_Development_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Backend_Development_Assignment_3.Services
{
    public interface IFranchiseService : IService<Franchise>
    {
        Task<IEnumerable<Movie>> GetMoviesFromFranchise(int id);
        Task<IEnumerable<Character>> GetCharactersFromFranchise(int id);
        Task PutMovieInFranchise(int id, int[] content);
    }
    public class FranchiseServices : IFranchiseService
    {
        private readonly DataStoreDbContext _context;

        public FranchiseServices(DataStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Franchise>> Get()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise> Get(int id)
        {
            return await _context.Franchises.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task Put(int id, Franchise entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Post(Franchise entity)
        {
            _context.Franchises.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Franchise entity)
        {
            // Set all franchiseIds of the movies in the franchise to null 
            var movies = await GetMoviesFromFranchise(entity.Id);
            foreach (var movie in movies)
            {
                movie.FranchiseId = null;
            }

            // Remove the franchise
            _context.Franchises.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public bool Exists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesFromFranchise(int id)
        {
            return await _context.Franchises.Where(m => m.Id == id).SelectMany(m => m.Movies).ToListAsync();
        }

        public async Task<IEnumerable<Character>> GetCharactersFromFranchise(int id)
        {
            return await _context.Franchises
                .Where(f => f.Id == id)
                .SelectMany(m => m.Movies)
                .SelectMany(m => m.Character)
                .Include(c => c.Movies)
                .Distinct()
                .ToListAsync();
        }

        public async Task PutMovieInFranchise(int id, int[] content)
        {
            var franchise = await _context.Franchises.FindAsync(id);


            for (int i = 0; i < content.Length; i++)
            {
                var movie = await _context.Movies.FindAsync(content[i]);

                movie.FranchiseId = franchise.Id;
                movie.Franchise = franchise;
            }

            await _context.SaveChangesAsync();
        }
    }
}
