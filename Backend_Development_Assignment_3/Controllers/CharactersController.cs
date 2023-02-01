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


        [HttpGet] // GET: api/Characters
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _service.Get());
        }


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


        [HttpPut("{id}")] // PUT: api/Characters/id
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(id, character);
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


        [HttpPost] // POST: api/Characters
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            try
            {
                await _service.Post(character);

                return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


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

        private bool CharacterExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
