namespace GradTech.DAL.DbAll.Entities;

public class Reservation
{
    public long ReservationId { get; set; }
    public long UnitId { get; set; }
    public long CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
    public virtual Unit Unit { get; set; }
    public virtual Customer Customer { get; set; }
    public ICollection<ReservationAdditionalOption> ReservationAdditionalOptions { get; set; }
}