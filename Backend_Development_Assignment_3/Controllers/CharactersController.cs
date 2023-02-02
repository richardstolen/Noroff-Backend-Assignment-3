using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Development_Assignment_3.Models;
using AutoMapper;
using Backend_Development_Assignment_3.Services;
using Backend_Development_Assignment_3.DTOs.CharacterDTOs;

namespace Backend_Development_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICharacterService _service;
        public CharactersController(IMapper mapper, ICharacterService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Get all characters.
        /// </summary>
        /// <returns></returns>
        [HttpGet] // GET: api/Characters
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _service.Get());
        }

        /// <summary>
        /// Get 1 Character with ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // GET: api/Characters/id
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var entity = _mapper.Map<CharacterReadDTO>(await _service.Get(id));

            if (entity == null)
            {
                return NotFound();
            }
            return entity;

        }

        /// <summary>
        /// Change Character with new data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")] // PUT: api/Characters/id
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO entityDTO)
        {
            var entity = _mapper.Map<Character>(entityDTO);
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
                if (!CharacterExists(id))
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
        /// Create new Character.
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        [HttpPost] // POST: api/Characters
        public async Task<ActionResult<CharacterPostDTO>> PostCharacter(CharacterPostDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Character>(entityDTO);
                await _service.Post(entity);

                return CreatedAtAction("GetCharacter", new { id = entity.Id }, entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete character with given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")] // DELETE: api/Characters/id
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

        /// <summary>
        /// Check if character exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CharacterExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
