using Microsoft.EntityFrameworkCore;
using Restaurants.API.Models;

namespace Restaurants.API.Data;

public class RestaurantsContext : DbContext
{
    public RestaurantsContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Reservation> Reservations { get; init; }
    public DbSet<Restaurant> Restaurants { get; init; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reservation>();
        modelBuilder.Entity<Restaurant>();
    }


}
