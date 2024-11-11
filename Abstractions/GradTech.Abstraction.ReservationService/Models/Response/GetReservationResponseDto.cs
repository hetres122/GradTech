namespace GradTech.Abstraction.ReservationService.Models;

public class GetReservationResponseDto
{
    public long ReservationId { get; set; }
    public long UnitId { get; set; }
    public string UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
}