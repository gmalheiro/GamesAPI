using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Models;

[Table("Genres")]
public class Genre
{
    public Genre()
    {
        Games = new Collection<Game>();
    }
    [Key]
    public int GenreId { get; set; }

    [Required(ErrorMessage = "Genres name is required")]
    [StringLength(50)]
    public string? GenreName { get; set; }

    public ICollection <Game>? Games { get; set; }
}

