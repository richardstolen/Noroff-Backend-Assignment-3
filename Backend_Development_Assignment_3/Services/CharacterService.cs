using Backend_Development_Assignment_3.Data;
using Backend_Development_Assignment_3.DTOs;
using Backend_Development_Assignment_3.DTOs.CharacterDTOs;
using Backend_Development_Assignment_3.Exceptions;
using Backend_Development_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Backend_Development_Assignment_3.Services
{
    public interface ICharacterService : IService<Character>
    {

    }
    public class CharacterServices : ICharacterService
    {
        private readonly DataStoreDbContext _context;

        public CharacterServices(DataStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> Get()
        {
            return await _context.Characters.Include(c => c.Movies).ToListAsync();
        }

        public async Task<Character> Get(int id)
        {
            return await _context.Characters.Include(c => c.Movies).Where(c => c.Id == id).FirstOrDefaultAsync();

        }

        public async Task Put(int id, Character entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Post(Character entity)
        {
            _context.Characters.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Character entity)
        {
            _context.Characters.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
