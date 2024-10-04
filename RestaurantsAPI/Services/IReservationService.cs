using MongoDB.Bson;
using Restaurants.API.Models;

namespace Restaurants.API.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetAllReservations();
    Task<Reservation> GetReservationById(int id);

    Task AddReservation(Reservation reservation);

    Task DeleteReservation(Reservation reservation);

    Task EditReservation(Reservation reservation);

}
