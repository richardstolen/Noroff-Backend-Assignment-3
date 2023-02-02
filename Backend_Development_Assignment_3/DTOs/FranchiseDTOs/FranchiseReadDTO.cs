using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.DTOs.FranchiseDTOs
{
    public class FranchiseReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
