using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Development_Assignment_3.Migrations
{
    public partial class Added_more_seeder_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureUrl" },
                values: new object[,]
                {
                    { 2, "null", "Arwen", 1, "https://static.wikia.nocookie.net/lotr/images/6/64/Arwen_-_The_Fellowship_Of_The_Ring.jpg/revision/latest/scale-to-width-down/322?cb=20210625164207" },
                    { 3, "null", "Aragorn", 0, "https://static.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest/scale-to-width-down/333?cb=20170121121423" },
                    { 4, "null", "Darth Vader", 0, "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Star_Wars_-_Darth_Vader.jpg/375px-Star_Wars_-_Darth_Vader.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "A Fascist government led by two religious fanatics with superpowers, is overthrown by a terrorist organisation supporting another off-shoot branch of religious fanatics with superpowers (who kidnap infants to indoctrinate them) and one of their heroes is space big-foot.", "Star Wars" });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MoviesId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MoviesId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PictureUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { 2, "George Lucas", 2, "Science fiction,Fantasy", "https://static.bokelskere.no/452990425bf3ebf21bbd5132dc0907472ee5a1f237f528af34fe14d1.jpeg", 2002, "Star Wars: Episode II — Attack of the Clones", "https://www.youtube.com/watch?v=gYbW1F_c9eM" });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MoviesId" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MoviesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MoviesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MoviesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
