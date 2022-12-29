using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    public partial class GamePopulating : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Games  (Name,Description,Price,GenreId)"
                   + "Values ('Call of Duty','A first person shooter game',60.00,1)");
            mb.Sql("INSERT INTO Games  (Name,Description,Price,GenreId)"
                + "Values  ('The legend of zelda','Explore an amazing RPG world',60.00,2)");
            mb.Sql("INSERT INTO Games  (Name,Description,Price,GenreId)"
                + "Values ('StarCraft','Battle with oponents using real time strategy',60.00,3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Games");
        }
    }
}
