using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Restaurants.API.Models;

[Collection("restaurants")]
public class Restaurant
{
    public int Id { get; set; }

    [Required(ErrorMessage = "You must provide a name")]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "You must the restaurant type")]
    [Display(Name = "Type")]
    public string? Type { get; set; }

    [Required(ErrorMessage = "You add the restaurant location")]
    [Display(Name = "Location")]
    public string? Location { get; set; }

}
