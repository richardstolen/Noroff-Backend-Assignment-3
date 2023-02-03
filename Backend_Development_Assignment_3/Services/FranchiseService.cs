using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Get all franchises.
        /// </summary>
        /// <returns>Collection of all Franchise objects in the database</returns>
        public async Task<IEnumerable<Franchise>> Get()
        {
            return await _context.Franchises.ToListAsync();
        }

        /// <summary>
        /// Get 1 franchise with ID.
        /// </summary>
        /// <param name="id">The id of the Franchise</param>
        /// <returns>Franchise object</returns>
        public async Task<Franchise> Get(int id)
        {
            return await _context.Franchises.Where(c => c.Id == id).FirstOrDefaultAsync();

        }

        /// <summary>
        /// Change franchise with new data.
        /// </summary>
        /// <param name="id">Id of the Franchise to update</param>
        /// <param name="entityDTO"></param>
        /// <returns>Bad request/NotFound/No Content</returns>
        public async Task Put(int id, Franchise entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Create new Franchise.
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns>Returns the created Franchise object or Bad Request</returns>
        public async Task Post(Franchise entity)
        {
            _context.Franchises.Add(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete franchise with given ID.
        /// </summary>
        /// <param name="id">Id of the Franchise to delete</param>
        /// <returns>Not Found/ No Content</returns>
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


        /// <summary>
        /// Check if franchise exists.
        /// </summary>
        /// <param name="id">Id of Franchise to check</param>
        /// <returns>True if Franchise exist in database and false if it doesn`t exist</returns>
        public bool Exists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }

        /// <summary>
        /// Get all the movies in a franchise.
        /// </summary>
        /// <param name="id">Id of the Franchise</param>
        /// <returns>Collection of movie objects in given Franchise</returns>
        public async Task<IEnumerable<Movie>> GetMoviesFromFranchise(int id)
        {
            return await _context.Franchises.Where(m => m.Id == id).SelectMany(m => m.Movies).ToListAsync();
        }


        /// <summary>
        /// Get all the characters in a franchise.
        /// </summary>
        /// <param name="id">Id of the Franchise you want to get all characters from</param>
        /// <returns>Collection of character objects for the given Franchise</returns>
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

        /// <summary>
        /// Update movies to be in a given franchise.
        /// </summary>
        /// <param name="id">Id of the Franchise to update</param>
        /// <param name="content"></param>
        /// <returns>Not Found/ No Content</returns>
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
