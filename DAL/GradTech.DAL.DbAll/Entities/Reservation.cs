namespace GradTech.DAL.DbAll.Entities;

public class Reservation
{
    public int ReservationId { get; set; }
    public int UnitId { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
    public virtual Unit Unit { get; set; }
    public virtual Customer Customer { get; set; }
    public ICollection<ReservationAdditionalOption> ReservationAdditionalOptions { get; set; }
}