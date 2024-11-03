using GradTech.Abstraction.ReservationService.Models;

namespace GradTech.Service.ReservationService.Interfaces;

public interface IReservationService
{
    public Task<List<GetReservationResponseDto>> GetReservations();
    
    public Task<GetReservationResponseDto> AddReservation(AddReservationRequestDto reservation);
    
    public Task<GetReservationResponseDto> EditReservation(EditReservationRequestDto reservation);
    
    public Task<GetReservationResponseDto> DeleteReservation(long reservationId);
}