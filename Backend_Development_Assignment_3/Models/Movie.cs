using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string? Genre { get; set; }

        public int ReleaseYear { get; set; }

        [MaxLength(25)]
        public string? Director { get; set; }

        [MaxLength(255)]
        public string? PictureUrl { get; set; }

        [MaxLength(255)]
        public string? TrailerUrl { get; set; }

        public ICollection<Character>? Character { get; set; }

        public int FranchiseId { get; set; }

        public Franchise? Franchise { get; set; }

    }
}
