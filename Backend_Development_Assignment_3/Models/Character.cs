namespace Backend_Development_Assignment_3.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string PictureUrl { get; set; }
    }
}
