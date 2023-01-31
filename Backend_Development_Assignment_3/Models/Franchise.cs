using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
