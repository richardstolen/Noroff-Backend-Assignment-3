using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.DTOs
{
    public class MovieReadDTO
    {
        public string Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }


    }
}
