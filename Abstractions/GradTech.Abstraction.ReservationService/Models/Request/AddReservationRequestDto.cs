namespace GradTech.Abstraction.ReservationService.Models;

public class AddReservationRequestDto
{
    public long UnitId { get; set; }
    public long CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
}