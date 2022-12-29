using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Models;

[Table("Games")]
public class Game
{
    [Key]
    public int GameId{ get; set; }

    [Required]
    [MaxLength(80)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(80)]
    public string? Description { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public int GenreId { get; set; }

    public string? GenreName { get;set; }
}

