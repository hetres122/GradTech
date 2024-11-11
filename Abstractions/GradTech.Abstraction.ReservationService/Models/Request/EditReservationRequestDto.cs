namespace GradTech.Abstraction.ReservationService.Models;

public class EditReservationRequestDto
{
    public long ReservationId { get; set; }
    public long UnitId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
}