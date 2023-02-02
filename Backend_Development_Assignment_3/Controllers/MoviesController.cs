using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Development_Assignment_3.Models;
using AutoMapper;
using Backend_Development_Assignment_3.Services;
using Backend_Development_Assignment_3.DTOs.MovieDTOs;

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
        /// Get all movies.
        /// </summary>
        /// <returns></returns>
        [HttpGet] // GET: api/Movies
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _service.Get());
        }

        /// <summary>
        /// Get 1 movie with ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")] // PUT: api/Movies/id
        public async Task<IActionResult> PutCharacter(int id, MoviePutDTO entityDTO)
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
        /// <returns></returns>
        [HttpPost] // POST: api/Movies
        public async Task<ActionResult<MoviePostDTO>> PostCharacter(MoviePostDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Movie>(entityDTO);
                await _service.Post(entity);

                return CreatedAtAction("GetCharacter", new { id = entity.Id }, entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete movie with given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")] // DELETE: api/Movies/id
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var entity = await _service.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            await _service.Delete(entity);

            return NoContent();
        }




        [HttpGet("Characters/{id}")] // GET: api/Characters/MovieId
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersFromMovies(int id)
        {
            var result = await _service.GetCharactersFromMovies(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

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
        /// Check if movie exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MovieExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
