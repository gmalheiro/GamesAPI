using System.Collections.ObjectModel;

namespace GamesAPI.Models;

public class Genre
{
    public Genre()
    {
        Games = new Collection<Game>();
    }

    public int GenreId { get; set; }

    public string? GenreName { get; set; }

    public ICollection <Game>? Games { get; set; }
}

