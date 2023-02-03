using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.Models
{
    /// <summary>
    /// Model of the table Franchise
    /// </summary>
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
