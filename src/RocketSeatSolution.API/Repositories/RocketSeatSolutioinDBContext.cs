using Microsoft.EntityFrameworkCore;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Repositories;

public class RocketSeatSolutioinDBContext : DbContext
{
    public RocketSeatSolutioinDBContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users{ get; set; }
    public DbSet<Offer> Offers{ get; set; }
}
