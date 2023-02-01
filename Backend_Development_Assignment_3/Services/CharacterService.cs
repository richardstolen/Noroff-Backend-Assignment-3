using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.DTOs;
using Backend_Development_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Development_Assignment_3.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetCharacters();

        Task<Character> GetCharacter(int id);
    }
    public class CharacterServices : ICharacterService
    {
        private readonly DataStoreDbContext _context;

        public CharacterServices(DataStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Character> GetCharacter(int id)
        {
            return await _context.Characters.Include(c => c.Movies).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _context.Characters.Include(c => c.Movies).ToListAsync();
        }
    }
}
