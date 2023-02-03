using Backend_Development_Assignment_3.DTOs.MovieDTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.DTOs.FranchiseDTOs
{
    public class FranchiseReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}
