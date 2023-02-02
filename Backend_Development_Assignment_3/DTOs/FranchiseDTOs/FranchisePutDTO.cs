using Backend_Development_Assignment_3.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Development_Assignment_3.DTOs.FranchiseDTOs
{
    public class FranchisePutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
