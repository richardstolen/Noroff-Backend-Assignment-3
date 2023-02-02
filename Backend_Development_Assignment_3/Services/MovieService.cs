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
    public interface IMovieService : IService<Movie>
    {
        Task<IEnumerable<Character>> GetCharactersFromMovies(int id);
        Task PutCharactersInMovie(int id, int[] content);
    }
    public class MovieServices : IMovieService
    {
        private readonly DataStoreDbContext _context;

        public MovieServices(DataStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            return await _context.Movies.Where(c => c.Id == id).FirstOrDefaultAsync();

        }

        public async Task Put(int id, Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Post(Movie entity)
        {
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetCharactersFromMovies(int id)
        {
            return await _context.Movies.Where(m => m.Id == id).SelectMany(m => m.Character).ToListAsync();
        }
        public async Task PutCharactersInMovie(int id, int[] content)
        {
            var movie = await _context.Movies.FindAsync(id);

            for (int i = 0; i < content.Length; i++)
            {
                var character = await _context.Characters.FindAsync(content[i]);

                movie.Character.Add(character);
            }
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }


    }
}
