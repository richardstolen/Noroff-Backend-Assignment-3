using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly DataStoreDbContext _context;

        public FranchisesController(DataStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return await _context.Franchises.ToListAsync();
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            _context.Entry(franchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Get all the movies in a franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetMovies/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesFromFranchise(int id)
        {
            var query = _context.Franchises.Where(m => m.Id == id).SelectMany(m => m.Movies);
            var result = await query.ToListAsync();

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
        /// Get all the characters in a franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCharacters/{id}")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersFromFranchise(int id)
        {
            var result = await _context.Franchises
                .Where(f => f.Id == id)
                .SelectMany(m => m.Movies)
                .SelectMany(m => m.Character)
                .ToListAsync();

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
        /// Update movies to be in a given franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPut("UpdateMovies/{id}")]
        public async Task<IActionResult> PutMovieInFranchise(int id, [FromBody] int[] content)
        {
            var franchise = await _context.Franchises.FindAsync(id);


            for (int i = 0; i < content.Length; i++)
            {
                var movie = await _context.Movies.FindAsync(content[i]);

                movie.FranchiseId = franchise.Id;
                movie.Franchise = franchise;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        private bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }
    }
}
