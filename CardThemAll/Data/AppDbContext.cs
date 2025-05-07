using CardThemAll.Models;
using Microsoft.EntityFrameworkCore;

namespace CardThemAll.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Card> PokemonCards { get; set; }
    }
}