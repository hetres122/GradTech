namespace GradTech.DAL.DbAll.Entities;

public class Reservation
{
    public long ReservationId { get; set; }
    public long UnitId { get; set; }
    public string UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
    public virtual Unit Unit { get; set; }
    public virtual ApplicationUser User { get; set; }
    public ICollection<ReservationAdditionalOption> ReservationAdditionalOptions { get; set; }
}