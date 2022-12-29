using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet <Genre>? Genres { get; set; }
        public DbSet <Game>? Games { get;set; }
    }
}
