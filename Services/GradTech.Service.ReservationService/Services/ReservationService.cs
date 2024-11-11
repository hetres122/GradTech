using GradTech.Abstraction.ReservationService.Models;
using GradTech.DAL.DbAll;
using GradTech.Service.ReservationService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GradTech.Service.ReservationService.Services;

public class ReservationService(DalContext dalContext) : IReservationService
{
    private readonly DalContext _dalContext = dalContext;
    
    public async Task<List<GetReservationResponseDto>> GetReservations(string userId)
    {
        var reservations = await _dalContext.Reservations
            .Where(reservation => reservation.UserId == userId)
            .Select(reservation => new GetReservationResponseDto
            {
                ReservationId = reservation.ReservationId,
                UnitId = reservation.UnitId,
                UserId = reservation.UserId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                TotalAmount = reservation.TotalAmount
            })
            .ToListAsync();
        
        return reservations;
    }
    
    public async Task<GetReservationResponseDto> AddReservation(AddReservationRequestDto reservation, string userId)
    {
        var newReservation = new DAL.DbAll.Entities.Reservation
        {
            UnitId = reservation.UnitId,
            UserId = userId,
            StartDate = reservation.StartDate,
            EndDate = reservation.EndDate,
            TotalAmount = reservation.TotalAmount
        };
        
        _dalContext.Reservations.Add(newReservation);
        
        await _dalContext.SaveChangesAsync();
        
        return new GetReservationResponseDto
        {
            ReservationId = newReservation.ReservationId,
            UnitId = newReservation.UnitId,
            UserId = newReservation.UserId,
            StartDate = newReservation.StartDate,
            EndDate = newReservation.EndDate
        };
    }
    
    public async Task<GetReservationResponseDto> EditReservation(EditReservationRequestDto reservation, string userId)
    {
        var reservationToEdit = await _dalContext.Reservations
            .Where(reservation => reservation.ReservationId == reservation.ReservationId)
            .FirstOrDefaultAsync();
        
        reservationToEdit.UnitId = reservation.UnitId;
        reservationToEdit.UserId = userId;
        reservationToEdit.StartDate = reservation.StartDate;
        reservationToEdit.EndDate = reservation.EndDate;
        reservationToEdit.TotalAmount = reservation.TotalAmount;
        
        await _dalContext.SaveChangesAsync();
        
        return new GetReservationResponseDto
        {
            ReservationId = reservationToEdit.ReservationId,
            UnitId = reservationToEdit.UnitId,
            UserId = reservationToEdit.UserId,
            StartDate = reservationToEdit.StartDate,
            EndDate = reservationToEdit.EndDate
        };
    }
    
    public async Task<GetReservationResponseDto> DeleteReservation(long reservationId)
    {
        var reservationToDelete = await _dalContext.Reservations
            .Where(reservation => reservation.ReservationId == reservationId)
            .FirstOrDefaultAsync();
        
        _dalContext.Reservations.Remove(reservationToDelete);
        
        await _dalContext.SaveChangesAsync();
        
        return new GetReservationResponseDto
        {
            ReservationId = reservationToDelete.ReservationId,
            UnitId = reservationToDelete.UnitId,
            UserId = reservationToDelete.UserId,
            StartDate = reservationToDelete.StartDate,
            EndDate = reservationToDelete.EndDate
        };
    }
}