namespace GamesAPI.Models;

public class Game
{
    public int GameId{ get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }    

    public decimal Price { get; set; }

    public int GenreId { get; set; }

    public string? GenreName { get;set; }
}

