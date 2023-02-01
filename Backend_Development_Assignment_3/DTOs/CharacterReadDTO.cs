using Backend_Development_Assignment_3.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.DTOs
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        public string? PictureUrl { get; set; }

        public ICollection<int> Movies { get; set; }
    }
}
