using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.DTOs;
using Backend_Development_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Development_Assignment_3.Services
{
    public interface ICharacterService
    {
        Task<ActionResult<IEnumerable<Character>>> GetCustomers();

        Task<ActionResult<Character>> GetCharacter(int id);
    }
    public class CharacterServices : ICharacterService
    {
        private readonly DataStoreDbContext _context;

        public CharacterServices(DataStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            return character;
        }

        public async Task<ActionResult<IEnumerable<Character>>> GetCustomers()
        {
            return await _context.Characters.ToListAsync();
        }
    }
}
