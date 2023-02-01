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
using Backend_Development_Assignment_3.DTOs;
using Backend_Development_Assignment_3.Services;

namespace Backend_Development_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly DataStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICharacterService _service;

        public CharactersController(DataStoreDbContext context, IMapper mapper, ICharacterService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }


        [HttpGet] // GET: api/Characters
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _service.GetCharacters());
        }


        [HttpGet("{id}")] // GET: api/Characters/id
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var character = _mapper.Map<CharacterReadDTO>(await _service.GetCharacter(id));

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

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }


        [HttpDelete("{id}")] // DELETE: api/Characters/id
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
