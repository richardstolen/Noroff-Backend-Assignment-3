using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Development_Assignment_3.Migrations
{
    public partial class Added_more_seeds_hobbit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureUrl" },
                values: new object[] { 7, "null", "Bilbo Baggins", 0, "https://static01.nyt.com/images/2012/12/14/arts/14HOBBIT/14HOBBIT-superJumbo.jpg" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureUrl" },
                values: new object[] { 8, "null", "Smaug", 0, "https://static.wikia.nocookie.net/lotr/images/6/6a/%22And_do_you_now%3F%22.JPG/revision/latest?cb=20210913160938" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PictureUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { 4, "Carolynne Cunningham", 1, "Fantasy", "https://static1.colliderimages.com/wordpress/wp-content/uploads/2021/08/the-hobbit-an-unexpected-journey.jpg?q=50&fit=contain&w=1140&h=&dpr=1.5", 2012, "The Hobbit - an unexpected journey", "https://www.youtube.com/watch?v=SDnYMbYB-nU" });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MoviesId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MoviesId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MoviesId" },
                values: new object[] { 8, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MoviesId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MoviesId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MoviesId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
