using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Restaurants.API.Models;
using Restaurants.API.Services;

namespace Restaurants.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController(IRestaurantService restaurantService) : ControllerBase
{
    private readonly IRestaurantService _restaurantService = restaurantService;


    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var response = await _restaurantService.GetAllRestaurants();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewRestaurant([FromBody] Restaurant newRestaurant)
    {
        await _restaurantService.AddRestaurant(newRestaurant);
        return Created();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetRestaurantById(int id)
    {
        var response = await _restaurantService.GetRestaurantById(id);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveRestaurant([FromBody] Restaurant restaurant)
    {
        await _restaurantService.DeleteRestaurant(restaurant);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRestaurant([FromBody] Restaurant restaurant)
    {
        await _restaurantService.EditRestaurant(restaurant);
        return Created();
    }
}
