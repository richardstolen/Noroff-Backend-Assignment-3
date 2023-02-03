using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

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

        // <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>List of movie objects</returns>
        public async Task<IEnumerable<Movie>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Get 1 movie by their id.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns>Movie object</returns>
        public async Task<Movie> Get(int id)
        {
            return await _context.Movies.Where(c => c.Id == id).FirstOrDefaultAsync();

        }

        /// <summary>
        /// Change movie with new data.
        /// </summary>
        /// <param name="id">Id of the movie you want to update</param>
        /// <param name="entityDTO"></param>
        /// <returns>Bad request/NotFound/NoContent</returns>
        public async Task Put(int id, Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Create new Movie.
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns>New movie details or Bad request</returns>
        public async Task Post(Movie entity)
        {
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete movie with given id.
        /// </summary>
        /// <param name="id">Id of the movie to delete</param>
        /// <returns>NotFound/NoContent</returns>
        public async Task Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all characters that are in a movie.
        /// </summary>
        /// <param name="id">Id of the movie where you want to get the characters from</param>
        /// <returns>Collection of character objects</returns>
        public async Task<IEnumerable<Character>> GetCharactersFromMovies(int id)
        {
            return await _context.Movies.Where(m => m.Id == id).SelectMany(m => m.Character).Include(c => c.Movies).ToListAsync();
        }

        /// <summary>
        /// Add characters to a Movie. Pass IDs of characters seperated by commas in a json string.
        /// </summary>
        /// <param name="id">Id of the movie you want to add characters to</param>
        /// <param name="content">Id of the characters you want to add to the movie. 
        /// The content paramters is an array of integers that represent the id of the characters being added to the movie</param>
        /// <returns>Not found/ No content</returns>
        public async Task PutCharactersInMovie(int id, int[] content)
        {
            var movie = await _context.Movies.FindAsync(id);
            var charactersInMovie = await GetCharactersFromMovies(id);

            for (int i = 0; i < content.Length; i++)
            {
                var character = await _context.Characters.FindAsync(content[i]);

                if (!charactersInMovie.Contains(character))
                {
                    movie.Character.Add(character);
                }
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if movie exists.
        /// </summary>
        /// <param name="id">Id of the movie to check</param>
        /// <returns>True if movie exists and False if the movie doesn`t exist</returns>
        public bool Exists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
