using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.Models;
using NuGet.Versioning;
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
            var character = _mapper.Map<CharacterReadDTO>(await _service.Get(id));

            if (character == null)
            {
                return NotFound();
            }
            return character;

        }

        /// <summary>
        /// Change Character with new data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPut("{id}")] // PUT: api/Characters/id
        public async Task<IActionResult> PutCharacter(int id, CharacterPutPostDTO character)
        {
            var charDTO = _mapper.Map<Character>(character);
            if (id != charDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(id, charDTO);
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
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost] // POST: api/Characters
        public async Task<ActionResult<CharacterPutPostDTO>> PostCharacter(CharacterPutPostDTO character)
        {
            try
            {
                var addCharacter = _mapper.Map<Character>(character);
                await _service.Post(addCharacter);

                return CreatedAtAction("GetCharacter", new { id = addCharacter.Id }, addCharacter);
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
            var character = await _service.Get(id);

            if (character == null)
            {
                return NotFound();
            }

            await _service.Delete(character);

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
