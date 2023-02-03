using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Development_Assignment_3.Models;
using AutoMapper;
using Backend_Development_Assignment_3.Services;
using Backend_Development_Assignment_3.DTOs.MovieDTOs;
using Backend_Development_Assignment_3.DTOs.CharacterDTOs;

namespace Backend_Development_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _service;

        public MoviesController(IMapper mapper, IMovieService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>List of movie objects</returns>
        [HttpGet] // GET: api/Movies
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _service.Get());
        }

        /// <summary>
        /// Get 1 movie by their id.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns>Movie object</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")] // GET: api/Movies/id
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var entity = _mapper.Map<MovieReadDTO>(await _service.Get(id));

            if (entity == null)
            {
                return NotFound();
            }
            return entity;

        }

        /// <summary>
        /// Change movie with new data.
        /// </summary>
        /// <param name="id">Id of the movie you want to update</param>
        /// <param name="entityDTO"></param>
        /// <returns>Bad request/NotFound/NoContent</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")] // PUT: api/Movies/id
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO entityDTO)
        {
            var entity = _mapper.Map<Movie>(entityDTO);
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(id, entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create new Movie.
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns>New movie details or Bad request</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost] // POST: api/Movies
        public async Task<ActionResult<Movie>> PostMovie(MoviePostDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Movie>(entityDTO);
                await _service.Post(entity);

                return CreatedAtAction("GetMovie", new { id = entity.Id }, entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete movie with given id.
        /// </summary>
        /// <param name="id">Id of the movie to delete</param>
        /// <returns>NotFound/NoContent</returns>
        [HttpDelete("{id}")] // DELETE: api/Movies/id
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var entity = await _service.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            await _service.Delete(entity);

            return NoContent();
        }


        /// <summary>
        /// Get all characters that are in a movie.
        /// </summary>
        /// <param name="id">Id of the movie where you want to get the characters from</param>
        /// <returns>Collection of character objects</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Characters/{id}")] // GET: api/Characters/MovieId
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharactersFromMovies(int id)
        {
            var result = _mapper.Map<List<CharacterReadDTO>>(await _service.GetCharactersFromMovies(id));

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Add characters to a Movie. Pass IDs of characters seperated by commas in a json string.
        /// </summary>
        /// <param name="id">Id of the movie you want to add characters to</param>
        /// <param name="content">Id of the characters you want to add to the movie. 
        /// The content paramters is an array of integers that represent the id of the characters being added to the movie</param>
        /// <returns>Not found/ No content</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("UpdateCharacters/{id}")]
        public async Task<IActionResult> PutCharactersInMovie(int id, [FromBody] int[] content)
        {
            try
            {
                await _service.PutCharactersInMovie(id, content);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Checks if movie exists.
        /// </summary>
        /// <param name="id">Id of the movie to check</param>
        /// <returns>True if movie exists and False if the movie doesn`t exist</returns>
        private bool MovieExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
