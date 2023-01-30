namespace Backend_Development_Assignment_3.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
