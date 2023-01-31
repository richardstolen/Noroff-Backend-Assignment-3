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
                },
                new Movie() {
                    Id=2,
                    Title="Star Wars: Episode II — Attack of the Clones",
                    Genre="Science fiction,Fantasy",
                    ReleaseYear=2002,
                    Director="George Lucas",
                    PictureUrl="https://static.bokelskere.no/452990425bf3ebf21bbd5132dc0907472ee5a1f237f528af34fe14d1.jpeg",
                    TrailerUrl="https://www.youtube.com/watch?v=gYbW1F_c9eM",
                    FranchiseId = 2,
                },
                new Movie() {
                    Id=3,
                    Title="Mamma Mia",
                    Genre="Musical",
                    ReleaseYear=2008,
                    Director="Phyllida Lloyd",
                    PictureUrl="https://m.media-amazon.com/images/M/MV5BMTA2MDU0MjM0MzReQTJeQWpwZ15BbWU3MDYwNzgwNzE@._V1_.jpg",
                    TrailerUrl="https://www.youtube.com/watch?v=lkN-A00WLYE",
                    FranchiseId=3,
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
                },
                new Character() {
                    Id=2,
                    FullName="Arwen",
                    Alias="null",
                    Gender=Gender.Female,
                    PictureUrl="https://static.wikia.nocookie.net/lotr/images/6/64/Arwen_-_The_Fellowship_Of_The_Ring.jpg/revision/latest/scale-to-width-down/322?cb=20210625164207"
                },
                new Character() {
                    Id=3,
                    FullName="Aragorn",
                    Alias="null",
                    Gender=Gender.Male,
                    PictureUrl="https://static.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest/scale-to-width-down/333?cb=20170121121423"
                },
                new Character() {
                    Id=4,
                    FullName="Darth Vader",
                    Alias="null",
                    Gender=Gender.Male,
                    PictureUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Star_Wars_-_Darth_Vader.jpg/375px-Star_Wars_-_Darth_Vader.jpg"
                },
                new Character() {
                    Id=5,
                    FullName="Sophie",
                    Alias="null",
                    Gender=Gender.Female,
                    PictureUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Amanda_Seyfried_%282019%29.jpg/375px-Amanda_Seyfried_%282019%29.jpg"
                },
                new Character() {
                    Id=6,
                    FullName="Ron Weasley",
                    Alias="null",
                    Gender=Gender.Female,
                    PictureUrl="https://upload.wikimedia.org/wikipedia/en/5/5e/Ron_Weasley_poster.jpg"
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
                },
                new Franchise() {
                    Id=2,
                    Name="Star Wars",
                    Description="A Fascist government led by two religious fanatics with superpowers, is overthrown by a terrorist organisation supporting another off-shoot branch of religious fanatics with superpowers (who kidnap infants to indoctrinate them) and one of their heroes is space big-foot.",
                },
                new Franchise() {
                    Id=3,
                    Name="Mamma mia",
                    Description="Singing in Greece",
                },
                 new Franchise() {
                    Id=4,
                    Name="Harry Potter",
                    Description="You are a wizard harry",
                }
            };
        }
        public static List<Dictionary<string, object>> SetRelationships()
        {
            return new List<Dictionary<string, object>>()
            {
               new Dictionary<string, object>() { ["CharacterId"] = 1, ["MoviesId"] = 1 },
               new Dictionary<string, object>() { ["CharacterId"] = 2, ["MoviesId"] = 1 },
               new Dictionary<string, object>() { ["CharacterId"] = 3, ["MoviesId"] = 1 },
               new Dictionary<string, object>() { ["CharacterId"] = 4, ["MoviesId"] = 2 },
               new Dictionary<string, object>() { ["CharacterId"] = 5, ["MoviesId"] = 3 },

            };
        }
    }
}
