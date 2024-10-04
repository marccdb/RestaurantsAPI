using MongoDB.Bson;
using Restaurants.API.Models;

namespace Restaurants.API.Services;

public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<Restaurant> GetRestaurantById(int id);

    Task AddRestaurant(Restaurant restaurant);

    Task DeleteRestaurant(Restaurant restaurant);

    Task EditRestaurant(Restaurant restaurant);

}
