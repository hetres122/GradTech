using GradTech.Abstraction.ReservationService.Models;

namespace GradTech.Service.ReservationService.Interfaces;

public interface IReservationService
{
    public Task<List<GetReservationResponseDto>> GetReservations(string userId);
    
    public Task<GetReservationResponseDto> AddReservation(AddReservationRequestDto reservation, string userId);
    
    public Task<GetReservationResponseDto> EditReservation(EditReservationRequestDto reservation, string userId);
    
    public Task<GetReservationResponseDto> DeleteReservation(long reservationId);
}