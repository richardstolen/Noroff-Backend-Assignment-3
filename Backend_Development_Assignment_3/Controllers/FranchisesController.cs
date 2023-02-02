using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.Models;
using AutoMapper;
using Backend_Development_Assignment_3.DTOs.CharacterDTOs;
using Backend_Development_Assignment_3.Services;
using Backend_Development_Assignment_3.DTOs.FranchiseDTOs;
using Backend_Development_Assignment_3.DTOs.MovieDTOs;

namespace Backend_Development_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all franchises.
        /// </summary>
        /// <returns></returns>
        [HttpGet] // GET: api/Franchise
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _service.Get());
        }

        /// <summary>
        /// Get 1 franchise with ID.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = await _service.Get(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
        }

        /// <summary>
        /// Change franchise with new data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")] // PUT: api/Franchises/id
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO entityDTO)
        {
            var entity = _mapper.Map<Franchise>(entityDTO);
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

        /// <summary>
        /// Create new Franchise.
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [HttpPost] // POST: api/Movies
        public async Task<ActionResult<Franchise>> PostFranchise(FranchisePostDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Franchise>(entityDTO);
                await _service.Post(entity);

                return CreatedAtAction("GetFranchise", new { id = entity.Id }, entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete franchise with given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")] // DELETE: api/Franchises/id
        public async Task<IActionResult> DeleteFranchise(int id)
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
        /// Get all the movies in a franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetMovies/{id}")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMoviesFromFranchise(int id)
        {
            var result = _mapper.Map<List<MovieReadDTO>>(await _service.GetMoviesFromFranchise(id));

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
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharactersFromFranchise(int id)
        {
            var result = _mapper.Map<List<CharacterReadDTO>>(await _service.GetCharactersFromFranchise(id));

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
            try
            {
                await _service.PutMovieInFranchise(id, content);
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

        /// <summary>
        /// Check if franchise exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool FranchiseExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
