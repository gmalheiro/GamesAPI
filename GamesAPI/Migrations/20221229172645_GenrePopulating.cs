using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    public partial class GenrePopulating : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Genres (GenreName) VALUES ('FPS')");
            mb.Sql("INSERT INTO Genres (GenreName) VALUES ('RPG')");
            mb.Sql("INSERT INTO Genres (GenreName) VALUES ('RTS')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Genres");
        }
    }
}
