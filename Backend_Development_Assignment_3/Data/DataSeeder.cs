using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Data
{
    public class DataSeeder
    {
        public static List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie() {
                    Id=1,
                    Title="The Fellowship of the Ring",
                    Genre="Fantasy",
                    ReleaseYear=2001,
                    Director="Peter Jackson",
                    PictureUrl="https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg",
                    TrailerUrl="https://www.youtube.com/watch?v=V75dMMIW2B4",
                    FranchiseId = 1,
                }
    };
        }

        public static List<Character> GetCharacters()
        {
            return new List<Character>()
            {
                new Character() {
                    Id=1,
                    FullName="Frodo Baggins",
                    Alias="null",
                    Gender=Gender.Male,
                    PictureUrl="https://static.wikia.nocookie.net/lotr/images/3/32/Frodo_%28FotR%29.png/revision/latest?cb=20221006065757"
                }
            };
        }

        public static List<Franchise> GetFranchises()
        {
            return new List<Franchise>()
            {
                new Franchise() {
                    Id=1,
                    Name="Lord of the rings",
                    Description="Frodo takes a ring to a mountain",
                }
            };
        }

        public static Dictionary<string, object> SetRelationships()
        {
            return new Dictionary<string, object>()

            { ["CharacterId"] = 1, ["MoviesId"] = 1 };

        }
    }
}
