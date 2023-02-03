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
    public interface ICharacterService : IService<Character> { }
    public class CharacterServices : ICharacterService
    {
        private readonly DataStoreDbContext _context;

        public CharacterServices(DataStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all characters in the database.
        /// </summary>
        /// <returns>A collection of character objects</returns>
        public async Task<IEnumerable<Character>> Get()
        {
            return await _context.Characters.Include(c => c.Movies).ToListAsync();
        }

        /// <summary>
        /// Gets a haracter by their id.
        /// </summary>
        /// <param name="id">Character`s id</param>
        /// <returns>A character object</returns>
        public async Task<Character> Get(int id)
        {
            return await _context.Characters.Include(c => c.Movies).Where(c => c.Id == id).FirstOrDefaultAsync();

        }

        /// <summary>
        /// Change character with new data.
        /// </summary>
        /// <param name="id">Character`s id</param>
        /// <param name="entityDTO"></param>
        /// <returns>Bad request/ Not Found/ No content</returns>
        public async Task Put(int id, Character entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a new Character.
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns>New character object</returns>
        public async Task Post(Character entity)
        {
            _context.Characters.Add(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete character with given ID.
        /// </summary>
        /// <param name="id">Id of deleted character</param>
        /// <returns>Not found/No content</returns>
        public async Task Delete(Character entity)
        {
            _context.Characters.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if character exists.
        /// </summary>
        /// <param name="id">Characters ud</param>
        /// <returns>Bool value. True if the character exists, False if it doesn`t exist</returns>
        public bool Exists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
