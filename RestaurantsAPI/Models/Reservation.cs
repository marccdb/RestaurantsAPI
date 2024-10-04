using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.API.Models;

[Collection("reservations")]
public class Reservation
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string? RestaurantName { get; set; }

    [Required(ErrorMessage = "The date and time is required to make this reservation")]
    [Display(Name = "Date")]
    public DateTime Date { get; set; }

}
