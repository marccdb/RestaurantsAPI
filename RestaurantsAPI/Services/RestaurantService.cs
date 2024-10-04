using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Restaurants.API.Data;
using Restaurants.API.Models;

namespace Restaurants.API.Services;

public class RestaurantService(RestaurantsContext context) : IRestaurantService
{
    private readonly RestaurantsContext _context = context;

    public async Task AddRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRestaurant(Restaurant restaurant)
    {
        var restaurantToDelete = await _context.Restaurants.Where(x => x.Id == restaurant.Id).FirstOrDefaultAsync();

        if (restaurantToDelete is null) { throw new Exception("Could not find the specified restaurant"); }

        _context.Restaurants.Remove(restaurantToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task EditRestaurant(Restaurant restaurant)
    {
        var restaurantToUpdate = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurant.Id);

        if (restaurantToUpdate is null) { throw new Exception("Could not find the specified restaurant"); }

        restaurantToUpdate.Name = restaurant.Name;
        restaurantToUpdate.Type = restaurant.Type;
        restaurantToUpdate.Location = restaurant.Location;
        await _context.SaveChangesAsync();

    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        return await _context.Restaurants.AsNoTracking().ToListAsync();
    }

    public async Task<Restaurant> GetRestaurantById(int id)
    {
        var restaurantToRetrieve = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (restaurantToRetrieve is null) { throw new Exception("Could not find the specified restaurant"); }

        return restaurantToRetrieve;

    }
}
