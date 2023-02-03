using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.DTOs.CharacterDTOs
{
    public class CharacterPostDTO
    {
        public string? FullName { get; set; }
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        public string? PictureUrl { get; set; }
    }
}
