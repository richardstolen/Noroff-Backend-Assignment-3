using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? FullName { get; set; }

        [MaxLength(50)]
        public string? Alias { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(255)]
        public string? PictureUrl { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
