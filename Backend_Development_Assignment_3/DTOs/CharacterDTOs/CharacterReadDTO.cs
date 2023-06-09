﻿using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.DTOs.CharacterDTOs
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        public string? PictureUrl { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}
