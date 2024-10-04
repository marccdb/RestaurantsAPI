using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Restaurants.API.Models;
using Restaurants.API.Services;

namespace Restaurants.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController(IReservationService reservationService) : ControllerBase
{
    private readonly IReservationService _reservationService = reservationService;


    [HttpGet]
    public async Task<IActionResult> GetAllReservations()
    {
        var response = await _reservationService.GetAllReservations();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewReservation([FromBody] Reservation newReservation)
    {
        await _reservationService.AddReservation(newReservation);
        return Created();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        var response = await _reservationService.GetReservationById(id);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveReservation([FromBody] Reservation reservation)
    {
        await _reservationService.DeleteReservation(reservation);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateReservation([FromBody] Reservation reservation)
    {
        await _reservationService.EditReservation(reservation);
        return Created();
    }
}
