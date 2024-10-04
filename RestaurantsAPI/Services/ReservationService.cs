using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Restaurants.API.Data;
using Restaurants.API.Models;

namespace Restaurants.API.Services;

public class ReservationService(RestaurantsContext context) : IReservationService
{
    private readonly RestaurantsContext _context = context;

    public async Task AddReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReservation(Reservation reservation)
    {
        var reservationToDelete = await _context.Reservations.Where(x => x.Id == reservation.Id).FirstOrDefaultAsync();

        if (reservationToDelete is null) { throw new Exception("Could not find the specified reservation"); }

        _context.Reservations.Remove(reservationToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task EditReservation(Reservation reservation)
    {
        var reservationToUpdate = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id);

        if (reservationToUpdate is null) { throw new Exception("Could not find the specified reservation"); }

        reservationToUpdate.RestaurantName = reservation.RestaurantName;
        reservationToUpdate.Date = reservation.Date;
        await _context.SaveChangesAsync();

    }

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await _context.Reservations.AsNoTracking().ToListAsync();
    }

    public async Task<Reservation> GetReservationById(int id)
    {
        var reservationToRetrieve = await _context.Reservations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (reservationToRetrieve is null) { throw new Exception("Could not find the specified reservation"); }

        return reservationToRetrieve;

    }
}
