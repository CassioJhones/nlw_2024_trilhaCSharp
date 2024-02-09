using Microsoft.EntityFrameworkCore;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Repositories;

public class RocketSeatSolutioinDBContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\cassi\Downloads\leilaoDbNLW.db");
    }
}
